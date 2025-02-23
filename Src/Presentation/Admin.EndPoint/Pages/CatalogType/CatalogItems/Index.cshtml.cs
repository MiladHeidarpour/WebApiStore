using Application.Catalogs.CatalogItems.CatalogItemServices;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType.CatalogItems;

public class IndexModel : PageModel
{
    private readonly ICatalogItemService _service;

    public IndexModel(ICatalogItemService service)
    {
        _service = service;
    }

    public PaginatedItemsDto<CatalogItemListDto> CatalogItems { get; set; }
    public void OnGet(int page = 1, int pageSize = 100)
    {
        CatalogItems = _service.GetCatalogList(page, pageSize);
    }
}