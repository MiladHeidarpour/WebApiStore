using Domain.Attributes;

namespace Domain.Catalogs;

[Auditable]
public class CatalogItemFavorite
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public CatalogItem CatalogItem { get; set; }
    public int CatalogItemId { get; set; }
}