using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Catalogs.CatalogItems.UriComposer;
using Application.Interfaces.Contexts;
using Domain.Banners;

namespace Application.HomePageService;

public interface IHomePageService
{
    HomePageDto GetData();
}

public class HomePageService : IHomePageService
{
    private readonly IDataBaseContext _context;
    private readonly IUriComposerService _uriComposerService;
    private readonly IGetCatalogItemPLPService _getCatalogItemPLPService;

    public HomePageService(IDataBaseContext context
        , IUriComposerService uriComposerService
        , IGetCatalogItemPLPService getCatalogItemPLPService)
    {
        _context = context;
        _uriComposerService = uriComposerService;
        _getCatalogItemPLPService = getCatalogItemPLPService;
    }


    public HomePageDto GetData()
    {
        var banners = _context.Banners.Where(p => p.IsActive == true)
            .OrderBy(p => p.Priority)
            .ThenByDescending(p => p.Id)
            .Select(p => new BannerDto
            {
                Id = p.Id,
                Image = _uriComposerService.ComposeImageUri(p.Image),
                Link = p.Link,
                Position = p.Position,
            }).ToList();

        var Bestselling = _getCatalogItemPLPService.Execute(new CatlogPLPRequestDto
        {
            AvailableStock = true,
            Page = 1,
            PageSize = 20,
            SortType = SortType.Bestselling
        }).Data.ToList();

        var MostPopular = _getCatalogItemPLPService.Execute(new CatlogPLPRequestDto
        {
            AvailableStock = true,
            Page = 1,
            PageSize = 20,
            SortType = SortType.MostPopular
        }).Data.ToList();

        return new HomePageDto
        {
            Banners = banners,
            bestSellers = Bestselling,
            MostPopular = MostPopular,
        };
    }
}

public class HomePageDto
{
    public List<BannerDto> Banners { get; set; }
    public List<CatalogPLPDto> MostPopular { get; set; }
    public List<CatalogPLPDto> bestSellers { get; set; }


}

public class BannerDto
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
    public Position Position { get; set; }
}