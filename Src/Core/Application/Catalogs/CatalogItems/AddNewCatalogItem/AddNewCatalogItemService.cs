using Application.Dtos;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Catalogs;
using FluentValidation;

namespace Application.Catalogs.CatalogItems.AddNewCatalogItem;

public class AddNewCatalogItemService : IAddNewCatalogItemService
{
    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;
    public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public BaseDto<int> Execute(AddNewCatalogItemDto request)
    {
        var catalogItem = _mapper.Map<CatalogItem>(request);
        _context.CatalogItems.Add(catalogItem);
        _context.SaveChanges();
        return new BaseDto<int>(true, new List<string> { "با موفقیت ثبت شد" }, catalogItem.Id);
    }
}
public class AddNewCatalogItemDtoValidator : AbstractValidator<AddNewCatalogItemDto>
{
    public AddNewCatalogItemDtoValidator()
    {
        RuleFor(p => p.Name).NotNull().WithMessage("نام کاتالوگ اجباری است");
        RuleFor(x => x.Name).Length(2, 100);
        RuleFor(x => x.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
        RuleFor(x => x.AvailableStock).InclusiveBetween(0, int.MaxValue);
        RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue);
        RuleFor(x => x.Price).NotNull();
    }
}