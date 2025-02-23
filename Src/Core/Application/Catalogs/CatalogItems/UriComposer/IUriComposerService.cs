namespace Application.Catalogs.CatalogItems.UriComposer;

public interface IUriComposerService
{
    string ComposeImageUri(string src);
}

public class UriComposerService : IUriComposerService
{
    public string ComposeImageUri(string src)
    {
        return "https://localhost:7141/" + src.Replace("\\", "//");
    }
}