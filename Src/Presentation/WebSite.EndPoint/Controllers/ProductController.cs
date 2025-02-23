using Application.Catalogs.CatalogItems.CatalogItemPDP;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers;

public class ProductController : Controller
{
    private readonly IGetCatalogItemPLPService _catalogPLPService;
    private readonly IGetCatalogItemPDPService _catalogPDPService;
    public ProductController(IGetCatalogItemPLPService catalogPLPService, IGetCatalogItemPDPService catalogPdpService)
    {
        _catalogPLPService = catalogPLPService;
        _catalogPDPService = catalogPdpService;
    }

    public IActionResult Index(int page = 1, int pageSize = 20)
    {
        var data = _catalogPLPService.Execute(page, pageSize);
        return View(data);
    }

    public IActionResult Details(int id)
    {
        var data = _catalogPDPService.Execute(id);
        return View(data);
    }
}