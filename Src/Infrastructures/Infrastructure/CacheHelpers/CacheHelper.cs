namespace Infrastructure.CacheHelpers;

public static class CacheHelper
{
    public static readonly TimeSpan DefaultCacheDuration=TimeSpan.FromSeconds(10);
    public static readonly string _ItemKeyTemplate="items-{0}-{1}-{2}";
    public static string GenerateHomePageCacheKey()
    {
        return "HomePage";
    }

    public static string GenerateCatalogItemCacheKey(int pageIndex, int itemsPage, int? typeId)
    {
        return string.Format(_ItemKeyTemplate, pageIndex, itemsPage, typeId);
    }
}