using Application.Catalogs.CatalogItems.UriComposer;
using Application.Dtos;
using Application.Interfaces.Contexts;
using Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogItems.GetCatalogItemPLP;

public interface IGetCatalogItemPLPService
{
    PaginatedItemsDto<CatalogPLPDto> Execute(CatlogPLPRequestDto request);
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

    public PaginatedItemsDto<CatalogPLPDto> Execute(CatlogPLPRequestDto request)
    {
        int rowCount = 0;
        var query = _context.CatalogItems
            .Include(p => p.Discounts)
            .Include(p => p.CatalogItemImages)
            .OrderByDescending(p => p.Id)
            .AsQueryable();

        if (request.BrandId != null)
        {
            query = query.Where(p => request.BrandId.Any(b => b == p.CatalogBrandId));
        }

        if (request.CatalogTypeId != null)
        {
            query = query.Where(p => p.CatalogTypeId == request.CatalogTypeId);
        }

        if (!string.IsNullOrEmpty(request.SearchKey))
        {
            query = query.Where(p => p.Name.Contains(request.SearchKey)
            || p.Description.Contains(request.SearchKey));
        }

        if (request.AvailableStock == true)
        {
            query = query.Where(p => p.AvailableStock > 0);
        }


        if (request.SortType == SortType.Bestselling)
        {
            query = query.Include(p => p.OrderItems)
                .OrderByDescending(p => p.OrderItems.Count());
        }

        if (request.SortType == SortType.MostPopular)
        {
            query = query.Include(p => p.CatalogItemFavorites)
                .OrderByDescending(p => p.CatalogItemFavorites.Count());
        }
        if (request.SortType == SortType.MostVisited)
        {
            query = query
                .OrderByDescending(p => p.VisitCount);
        }

        if (request.SortType == SortType.Newest)
        {
            query = query
                .OrderByDescending(p => p.Id);
        }

        if (request.SortType == SortType.Cheapest)
        {
            query = query
                .Include(p => p.Discounts)
                .OrderBy(p => p.Price);
        }

        if (request.SortType == SortType.MostExpensive)
        {
            query = query
                .Include(p => p.Discounts)
                .OrderByDescending(p => p.Price);
        }

        var data = query.PagedResult(request.Page, request.PageSize, out rowCount)
            .ToList()
            .Select(p => new CatalogPLPDto
            {
                Id = p.Id,
                Slug = p.Slug,
                Name = p.Name,
                Price = p.Price,
                Rate = 4,
                Image = _uriService
                .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                AvailableStock = p.AvailableStock,
            }).ToList();
        return new PaginatedItemsDto<CatalogPLPDto>(request.Page, request.PageSize, rowCount, data);
    }
}

public class CatlogPLPRequestDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? CatalogTypeId { get; set; }
    public int[] BrandId { get; set; }
    public bool AvailableStock { get; set; }
    public string SearchKey { get; set; }
    public SortType SortType { get; set; }
}


public enum SortType
{
    /// <summary>
    /// بدونه مرتب سازی
    /// </summary>
    None = 0,
    /// <summary>
    /// پربازدیدترین
    /// </summary>
    MostVisited = 1,
    /// <summary>
    /// پرفروش‌ترین
    /// </summary>
    Bestselling = 2,
    /// <summary>
    /// محبوب‌ترین
    /// </summary>
    MostPopular = 3,
    /// <summary>
    ///  ‌جدیدترین
    /// </summary>
    Newest = 4,
    /// <summary>
    /// ارزان‌ترین
    /// </summary>
    Cheapest = 5,
    /// <summary>
    /// گران‌ترین
    /// </summary>
    MostExpensive = 6,
}

public class CatalogPLPDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int Rate { get; set; }
    public int AvailableStock { get; set; }
}