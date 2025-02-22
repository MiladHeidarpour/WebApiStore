using Application.Interfaces.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogItems.CatalogItemServices;

public interface ICatalogItemService
{
    List<CatalogBrandDto> GetBrand();
    List<ListCatalogTypeDto> GetCatalogType();
}
public class CatalogItemService : ICatalogItemService
{

    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;

    public CatalogItemService(IDataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<CatalogBrandDto> GetBrand()
    {
        var brands = _context.CatalogBrands
            .OrderBy(p => p.Brand).Take(500).ToList();

        var data = _mapper.Map<List<CatalogBrandDto>>(brands);
        return data;
    }

    public List<ListCatalogTypeDto> GetCatalogType()
    {
        var types = _context.CatalogTypes
            .Include(p => p.ParentCatalogType)
            .Include(p => p.ParentCatalogType)
            .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
            .Include(p => p.SubType)
            .Where(p => p.ParentCatalogTypeId != null)
            .Where(p => p.SubType.Count == 0)
            .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType })
            .ToList()
            .Select(p => new ListCatalogTypeDto
            {
                Id = p.Id,
                Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
            }).ToList();
        return types;
    }
}
public class CatalogBrandDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
}
public class ListCatalogTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; }
}