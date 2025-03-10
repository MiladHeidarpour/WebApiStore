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

    public IActionResult Index(CatlogPLPRequestDto request)
    {
        var data = _catalogPLPService.Execute(request);
        return View(data);
    }

    public IActionResult Details(string slug)
    {
        var data = _catalogPDPService.Execute(slug);
        return View(data);
    }
}