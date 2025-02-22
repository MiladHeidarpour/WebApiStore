using Application.Dtos;

namespace Application.Catalogs.CatalogItems.AddNewCatalogItem;

public interface IAddNewCatalogItemService
{
    BaseDto<int> Execute(AddNewCatalogItemDto request);
}

public class AddNewCatalogItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CatalogTypeId { get; set; }
    public int CatalogBrandId { get; set; }
    public int AvailableStock { get; set; }
    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }
    public List<AddNewCatalogItemFeatureDto> CatalogItemFeatures { get; set; }
    public List<AddNewCatalogItemImageDto> CatalogItemImages { get; set; }
}

public class AddNewCatalogItemFeatureDto
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Group { get; set; }
}

public class AddNewCatalogItemImageDto
{
    public string Src { get; set; }
}