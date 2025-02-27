using System.Text;
using Application.Payments;
using Domain.Payments;
using Dto.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
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
    public IActionResult Verify(Guid id, string authority)
    {
        string status = HttpContext.Request.Query["Status"];
        if (status!=""&&status.ToString().ToLower()=="ok"&&authority!="")
        {
            var payment = _paymentService.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }

            var client = new RestClient("https://sandbox.zarinpal.com/pg/v4/payment/verify.json");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\"merchant_id\" :\"{merchantId}\",\"authority\":\"{authority}\",\"amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
            var response = client.Execute(request);

            //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

            var responseObject = JsonConvert.DeserializeObject<RootObject>(response.Content);
            VerificationPayResultDto verification = new VerificationPayResultDto
            {
                Status = responseObject.Data.Code,
                RefID = responseObject.Data.Ref_ID,
            };

            if (verification.Status == 100)
            {
                bool verifyResult = _paymentService.VerifyPayment(id, authority, verification.RefID);
                if (verifyResult)
                {
                    return Redirect("/customers/orders/");
                }
                else
                {
                    TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
                    return RedirectToAction("checkout", "basket");
                }
            }
            else
            {
                TempData["message"] = "پرداخت شما ناموفق بوده است . لطفا مجددا تلاش نمایید یا در صورت بروز مشکل با مدیریت سایت تماس بگیرید .";
                return RedirectToAction("checkout", "basket");
            }

        }
        TempData["message"] = "پرداخت شما ناموفق بوده است .";
        return RedirectToAction("checkout", "basket");
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


    public class ResponseData
    {
        public int Code { get; set; }
        public long Ref_ID { get; set; }
        public string Message { get; set; }
    }
    public class RootObject
    {
        public ResponseData Data { get; set; }
        public List<object> Errors { get; set; }
    }
    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}