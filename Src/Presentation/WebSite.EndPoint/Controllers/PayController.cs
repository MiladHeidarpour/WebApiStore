using System.Text;
using Application.Payments;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WebSite.EndPoint.Utilities;
using ZarinPal.Class;

namespace WebSite.EndPoint.Controllers;

public class PayController : Controller
{
    private readonly IPaymentService _paymentService;

    private static readonly HttpClient client = new HttpClient();
    private const string merchantId = "9b9eef82-7cde-11e7-b794-000c295eb8fc"; //zarinpal test
    private readonly string mainUrl = "https://localhost:7032";
    private readonly string requestUrl = "https://sandbox.zarinpal.com/pg/v4/payment/request.json";
    private readonly string verifyurl = "https://sandbox.zarinpal.com/pg/v4/payment/verify.json";

    public PayController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }


    public async Task<IActionResult> Index(Guid paymentId)
    {
        var payment = _paymentService.GetPayment(paymentId);
        if (payment == null)
        {
            return NotFound();
        }

        string userId = ClaimUtility.GetUserId(User);
        if (userId != payment.UserId)
        {
            return BadRequest();
        }

        string callbackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);


        //create json request
        var requestData = new Dictionary<string, string>
        {
            {"merchant_id",merchantId },
            {"amount",payment.Amount.ToString() },
            {"callback_url",callbackUrl },
            {"mobile",payment.PhoneNumber },
            {"description",payment.Description },
            {"email",payment.Email },
        };

        //create json request
        var paymentRequestJson = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(paymentRequestJson, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(requestUrl, content);
        var responseString = await response.Content.ReadAsStringAsync();
        RequestModel result = JsonConvert.DeserializeObject<RequestModel>(responseString);
        return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Data.Authority);
    }
    public IActionResult Verify(Guid Id, string Authority)
    {
        return View();
    }
    public class RequestModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public DataModel Data { get; set; } // اضافه کردن DataModel برای نگهداری داده‌های داخل "data"
        public List<string> Errors { get; set; }
    }

    public class DataModel
    {
        public string Authority { get; set; }
        public int Fee { get; set; }
        public string FeeType { get; set; }
    }
}