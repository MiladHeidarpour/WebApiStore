using Domain.Attributes;

namespace Domain.Catalogs;

[Auditable]
public class CatalogBrand
{
    public int Id { get; set; }
    public string Brand { get; set; }
}