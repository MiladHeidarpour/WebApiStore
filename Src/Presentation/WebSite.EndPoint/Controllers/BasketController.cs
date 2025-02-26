using Application.BasketsService;
using Application.Orders;
using Application.Payments;
using Application.Users;
using Domain.Catalogs;
using Domain.Orders;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels.Baskets;
using WebSite.EndPoint.Utilities;

namespace WebSite.EndPoint.Controllers;

[Authorize]
public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IUserAddressService _userAddressService;
    private readonly IOrderService _orderService;
    private readonly SignInManager<User> _signInManager;
    private readonly IPaymentService _paymentService;
    private string userId = null;

    public BasketController(IBasketService basketService, SignInManager<User> signInManager, IUserAddressService userAddressService, IOrderService orderService, IPaymentService paymentService)
    {
        _basketService = basketService;
        _signInManager = signInManager;
        _userAddressService = userAddressService;
        _orderService = orderService;
        _paymentService = paymentService;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var data = GetOrSetBasket();
        return View(data);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Index(int catalogItemId, int quantity = 1)
    {
        var basket = GetOrSetBasket();
        _basketService.AddItemToBasket(basket.Id, catalogItemId, quantity);
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult RemoveItemFromBasket(int itemId)
    {
        _basketService.RemoveItemFromBasket(itemId);
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult SetQuantity(int basketItemId, int quantity)
    {
        return Json(_basketService.SetQuantities(basketItemId, quantity));
    }

    public IActionResult ShippingPayment()
    {
        ShippingPaymentViewModel viewModel = new ShippingPaymentViewModel();
        string userId = ClaimUtility.GetUserId(User);
        viewModel.Basket = _basketService.GetBasketForUser(userId);
        viewModel.UserAddresses = _userAddressService.GetAddresses(userId);
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
    {
        string userId = ClaimUtility.GetUserId(User);
        var basket = _basketService.GetBasketForUser(userId);
        int orderId = _orderService.CreateOrder(basket.Id, Address, PaymentMethod);
        if (PaymentMethod == PaymentMethod.OnlinePaymnt)
        {
            var payment = _paymentService.PayForOrder(orderId);

            return RedirectToAction("Index", "Pay", new { paymentId = payment.PaymentId });
        }
        else
        {
            return RedirectToAction("Index", "Orders", new { area = "Customers" });
        }
    }
    private BasketDto GetOrSetBasket()
    {
        if (_signInManager.IsSignedIn(User))
        {
            userId = ClaimUtility.GetUserId(User);
            return _basketService.GetOrCreateBasketForUser(userId);
        }
        else
        {
            SetCookiesForBasket();
            return _basketService.GetOrCreateBasketForUser(userId);
        }
    }
    private void SetCookiesForBasket()
    {
        string basketCookieName = "BasketId";
        if (Request.Cookies.ContainsKey(basketCookieName))
        {
            userId = Request.Cookies[basketCookieName];
        }
        if (userId != null) return;
        userId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { IsEssential = true };
        cookieOptions.Expires = DateTime.Today.AddYears(2);
        Response.Cookies.Append(basketCookieName, userId, cookieOptions);
    }
}