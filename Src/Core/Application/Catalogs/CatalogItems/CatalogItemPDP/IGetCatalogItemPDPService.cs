using Application.Catalogs.CatalogItems.UriComposer;
using Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogItems.CatalogItemPDP;

public interface IGetCatalogItemPDPService
{
    CatalogItemPDPDto Execute(int Id);
}

public class GetCatalogItemPDPService : IGetCatalogItemPDPService
{
    private readonly IDataBaseContext _context;
    private readonly IUriComposerService _uriService;

    public GetCatalogItemPDPService(IDataBaseContext context, IUriComposerService uriService)
    {
        _context = context;
        _uriService = uriService;
    }

    public CatalogItemPDPDto Execute(int Id)
    {
        var catalogitem = _context.CatalogItems
            .Include(p => p.CatalogItemFeatures)
            .Include(p => p.CatalogItemImages)
            .Include(p => p.CatalogType)
            .Include(p => p.CatalogBrand)
            .SingleOrDefault(p => p.Id == Id);

        var feature = catalogitem.CatalogItemFeatures
            .Select(p => new PDPFeaturesDto
            {
                Group = p.Group,
                Key = p.Key,
                Value = p.Value
            }).ToList()
            .GroupBy(p => p.Group);

        var similarCatalogItems = _context
            .CatalogItems
            .Include(p => p.CatalogItemImages)
            .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
            .Take(10)
            .Select(p => new SimilarCatalogItemDto
            {
                Id = p.Id,
                Images = _uriService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                Price = p.Price,
                Name = p.Name
            }).ToList();

        return new CatalogItemPDPDto
        {
            Features = feature,
            SimilarCatalogs = similarCatalogItems,
            Id = catalogitem.Id,
            Name = catalogitem.Name,
            Brand = catalogitem.CatalogBrand.Brand,
            Type = catalogitem.CatalogType.Type,
            Price = catalogitem.Price,
            Description = catalogitem.Description,
            Images = catalogitem.CatalogItemImages.Select(p => _uriService.ComposeImageUri(p.Src)).ToList(),

        };
    }
}


public class CatalogItemPDPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int Price { get; set; }
    public List<string> Images { get; set; }
    public string Description { get; set; }
    public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
    public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }

}

public class PDPFeaturesDto
{
    public string Group { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}


public class SimilarCatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Images { get; set; }
}