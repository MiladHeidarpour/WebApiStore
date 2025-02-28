using Application.Discounts.DiscountServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.EndPoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountApiController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountApiController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    [Route("SearchCatalogItem")]
    public async Task<IActionResult> SearchCatalogItem (string? term=null)
    {
        return Ok(_discountService.GetCatalogItems(term));
    }
}