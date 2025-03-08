using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Application.HomePageService;
using Infrastructure.CacheHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using WebSite.EndPoint.Models;
using WebSite.EndPoint.Utilities.Filters;

namespace WebSite.EndPoint.Controllers;


[ServiceFilter(typeof(SaveVisitorFilter))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomePageService _homePageService;
    private readonly IDistributedCache _cache;
    public HomeController(ILogger<HomeController> logger, IHomePageService homePageService, IDistributedCache cache)
    {
        _logger = logger;
        _homePageService = homePageService;
        _cache = cache;
    }

    public IActionResult Index()
    {
        HomePageDto homePageData = new HomePageDto();

        var homePageCache= _cache.GetAsync(CacheHelper.GenerateHomePageCacheKey()).Result;

        if (homePageCache!=null)
        {
            homePageData = JsonSerializer.Deserialize<HomePageDto>(homePageCache);
        }
        else
        {
            homePageData= _homePageService.GetData();
            string jsonData = JsonSerializer.Serialize(homePageData);
            byte[] encodedJson = Encoding.UTF8.GetBytes(jsonData);
            var options = new DistributedCacheEntryOptions().SetSlidingExpiration(CacheHelper.DefaultCacheDuration);
            _cache.SetAsync(CacheHelper.GenerateHomePageCacheKey(), encodedJson, options);
        }

        return View(homePageData);
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