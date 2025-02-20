using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Dtos;
using Application.Dtos.CatalogTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeService _catalogTypeService;

        public IndexModel(ICatalogTypeService catalogTypeService)
        {
            _catalogTypeService = catalogTypeService;
        }

        public PaginatedItemsDto<CatalogTypeListDto> CatalogType { get; set; }
        public void OnGet(int? parentId, int page = 1, int pageSize = 100)
        {
            CatalogType = _catalogTypeService.GetList(parentId, page, pageSize);
        }
    }
}
