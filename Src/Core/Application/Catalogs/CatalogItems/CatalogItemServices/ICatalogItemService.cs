using Application.Dtos;

namespace Application.Catalogs.CatalogItems.CatalogItemServices;

public interface ICatalogItemService
{
    List<CatalogBrandDto> GetBrand();
    List<ListCatalogTypeDto> GetCatalogType();
    PaginatedItemsDto<CatalogItemListDto> GetCatalogList(int page, int pageSize);
    void AddToMyFavorite(string userId, int catalogItemId);
    PaginatedItemsDto<FavoriteCatalogItemDto> GetMyFavorite(string userId, int page = 1, int pageSize = 20);
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

public class CatalogItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }
}

public class FavoriteCatalogItemDto
{
    public int Id { get; set; }
    public int Price { get; set; }
    public int Rate { get; set; }
    public int AvailableStock { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
}