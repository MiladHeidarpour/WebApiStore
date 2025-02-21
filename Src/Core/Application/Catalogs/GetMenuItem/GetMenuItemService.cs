using Application.Interfaces.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.GetMenuItem;

public class GetMenuItemService : IGetMenuItemService
{
    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;

    public GetMenuItemService(IDataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<MenuItemDto> Execute()
    {
        var catalogType = _context.CatalogTypes.Include(p => p.ParentCatalogType)
            .ToList();
        var data = _mapper.Map<List<MenuItemDto>>(catalogType);
        return data;
    }
}