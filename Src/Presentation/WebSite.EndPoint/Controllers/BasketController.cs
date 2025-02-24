using Application.BasketsService;
using Domain.Catalogs;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers;

public class BasketController : Controller
{
    private readonly IBasketService _basketService;
    private readonly SignInManager<User> _signInManager;
    private string userId = null;

    public BasketController(IBasketService basketService, SignInManager<User> signInManager)
    {
        _basketService = basketService;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        var data = GetOrSetBasket();
        return View(data);
    }
    [HttpPost]
    public IActionResult Index(int catalogItemId, int quantity = 1)
    {
        var basket = GetOrSetBasket();
        _basketService.AddItemToBasket(basket.Id, catalogItemId, quantity);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult RemoveItemFromBasket(int itemId)
    {
        _basketService.RemoveItemFromBasket(itemId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult SetQuantity(int basketItemId, int quantity)
    {
        return Json(_basketService.SetQuantities(basketItemId, quantity));
    }
    private BasketDto GetOrSetBasket()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return _basketService.GetOrCreateBasketForUser(User.Identity.Name);
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