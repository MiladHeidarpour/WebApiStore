using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Dtos;
using Application.Dtos.CatalogTypes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class CreateModel : PageModel
    {
        private readonly ICatalogTypeService _catalogTypeService;
        private readonly IMapper _mapper;

        public CreateModel(ICatalogTypeService catalogTypeService, IMapper mapper)
        {
            _catalogTypeService = catalogTypeService;
            _mapper = mapper;
        }

        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel { };
        public List<String> Message { get; set; } = new List<string>();

        public void OnGet(int? parentId)
        {
            CatalogType.ParentCatalogTypeId = parentId;
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var model = _mapper.Map<CatalogTypeDto>(CatalogType);
            var result = _catalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToPage("index", new { parentid = CatalogType.ParentCatalogTypeId });
            }
            Message = result.Message;
            return Page();
        }
    }
}
