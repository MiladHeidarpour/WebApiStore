using Application.Dtos;
using Application.Interfaces.Contexts;
using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogItems.CatalogItemServices;

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

    public PaginatedItemsDto<CatalogItemListDto> GetCatalogList(int page, int pageSize)
    {
        int rowCount = 0;
        var data = _context.CatalogItems.Include(p => p.CatalogType)
            .Include(p => p.CatalogBrand)
            .ToPaged(page, pageSize, out rowCount).OrderByDescending(p => p.Id)
            .Select(p => new CatalogItemListDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Brand = p.CatalogBrand.Brand,
                Type = p.CatalogType.Type,
                AvailableStock = p.AvailableStock,
                RestockThreshold = p.RestockThreshold,
                MaxStockThreshold = p.MaxStockThreshold,
            }).ToList();

        return new PaginatedItemsDto<CatalogItemListDto>(page, pageSize, rowCount, data);
    }
}