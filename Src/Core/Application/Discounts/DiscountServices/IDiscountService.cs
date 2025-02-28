using Application.Interfaces.Contexts;

namespace Application.Discounts.DiscountServices;

public interface IDiscountService
{
    List<CatalogItemDto> GetCatalogItems(string? searchKey);
}

public class DiscountService:IDiscountService
{
    private readonly IDataBaseContext _context;

    public DiscountService(IDataBaseContext context)
    {
        _context = context;
    }

    public List<CatalogItemDto> GetCatalogItems(string? searchKey=null)
    {
        if (!string.IsNullOrEmpty(searchKey))
        {
            var data = _context.CatalogItems.Where(p => p.Name.Contains(searchKey)).Select(p=>new CatalogItemDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return data;
        }
        else
        {
            var data = _context.CatalogItems.OrderByDescending(p=>p.Id).Take(10).Select(p => new CatalogItemDto()
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return data;
        }
    }
}

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}