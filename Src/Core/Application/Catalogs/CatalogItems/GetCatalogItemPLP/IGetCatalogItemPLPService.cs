using Application.Catalogs.CatalogItems.UriComposer;
using Application.Dtos;
using Application.Interfaces.Contexts;
using Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogItems.GetCatalogItemPLP;

public interface IGetCatalogItemPLPService
{
    PaginatedItemsDto<CatalogPLPDto> Execute(int page,int pageSize);
}

public class GetCatalogItemPLPService : IGetCatalogItemPLPService
{
    private readonly IDataBaseContext _context;
    private readonly IUriComposerService _uriService;

    public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uriService)
    {
        _context = context;
        _uriService = uriService;
    }

    public PaginatedItemsDto<CatalogPLPDto> Execute(int page, int pageSize)
    {
        int rowCount = 0;
        var data = _context.CatalogItems
            .Include(p => p.CatalogItemImages)
            .OrderByDescending(p => p.Id)
            .PagedResult(page, pageSize, out rowCount)
            .Select(p => new CatalogPLPDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Rate = 4,
                Image = _uriService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
            }).ToList();
        return new PaginatedItemsDto<CatalogPLPDto>(page, pageSize, rowCount, data);
    }
}

public class CatalogPLPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int Rate { get; set; }
}