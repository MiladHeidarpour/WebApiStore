using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.HomePageService;
using Microsoft.AspNetCore.Authorization;
using WebSite.EndPoint.Models;
using WebSite.EndPoint.Utilities.Filters;

namespace WebSite.EndPoint.Controllers;


[ServiceFilter(typeof(SaveVisitorFilter))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomePageService _homePageService;
    public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
    {
        _logger = logger;
        _homePageService = homePageService;
    }

    public IActionResult Index()
    {
        var data = _homePageService.GetData();
        return View(data);
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}