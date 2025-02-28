using Admin.EndPoint.Binders;
using Application.Discounts.AddNewDiscountService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Discounts;

public class CreateModel : PageModel
{
    private readonly IAddNewDiscountService _service;

    public CreateModel(IAddNewDiscountService service)
    {
        _service = service;
    }

    [ModelBinder(BinderType = typeof(DiscountEntityBinder))]
    [BindProperty]
    public AddNewDiscountDto model { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        _service.Execute(model);
    }
}