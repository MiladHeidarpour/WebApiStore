using Application.Catalogs.CatalogItems.CatalogItemServices;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Customers.Controllers;

[Authorize]
[Area("Customers")]
public class MyFavoriteController : Controller
{
    private readonly ICatalogItemService _catalogItemService;
    private readonly UserManager<User> _userManager;

    public MyFavoriteController(ICatalogItemService catalogItemService, UserManager<User> userManager)
    {
        _catalogItemService = catalogItemService;
        _userManager = userManager;
    }

    public IActionResult Index(int page=1, int pageSize=20)
    {
        var user = _userManager.GetUserAsync(User).Result;
        var data = _catalogItemService.GetMyFavorite(user.Id, page, pageSize);
        return View(data);
    }

    public IActionResult AddToMyFavorite(int catalogItemId)
    {
        var user = _userManager.GetUserAsync(User).Result;
        _catalogItemService.AddToMyFavorite(user.Id,catalogItemId);
        return RedirectToAction(nameof(Index));
    }
}