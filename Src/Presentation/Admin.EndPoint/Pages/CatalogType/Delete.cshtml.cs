using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.CatalogTypes.CrudService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.CatalogType
{
    public class DeleteModel : PageModel
    {
        private readonly ICatalogTypeService _catalogTypeService;
        private readonly IMapper _mapper;

        public DeleteModel(ICatalogTypeService catalogTypeService, IMapper mapper)
        {
            _catalogTypeService = catalogTypeService;
            _mapper = mapper;
        }

        [BindProperty]
        public CatalogTypeViewModel CatalogType { get; set; } = new CatalogTypeViewModel();
        public List<String> Message { get; set; } = new List<string>();
        public void OnGet(int Id)
        {
            var model = _catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                CatalogType = _mapper.Map<CatalogTypeViewModel>(model.Data);
             Message = model.Message;
        }

        public IActionResult OnPost()
        {
            var result = _catalogTypeService.Remove(CatalogType.Id);
            Message = result.Message;
            if (result.IsSuccess)
            {
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
