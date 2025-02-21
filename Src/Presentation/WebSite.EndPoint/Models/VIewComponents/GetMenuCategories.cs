using Application.Catalogs.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Models.VIewComponents;

public class GetMenuCategories : ViewComponent
{
    private readonly IGetMenuItemService _menuItemService;
    public GetMenuCategories(IGetMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    public IViewComponentResult Invoke()
    {
        var data = _menuItemService.Execute();
        return View(viewName: "GetMenuCategories", model: data);
    }
}