namespace Application.Catalogs.GetMenuItem;

public interface IGetMenuItemService
{
    List<MenuItemDto> Execute();
}

public class MenuItemDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int? ParentCatalogTypeId { get; set; }
    public List<MenuItemDto> SubType { get; set; }
}