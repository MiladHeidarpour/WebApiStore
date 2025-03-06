using Application.Interfaces.Contexts;
using Domain.Banners;
using System.ComponentModel.DataAnnotations;

namespace Application.Banners;

public interface IBannerService
{
    void AddBanner(BannerDto banner);
    List<BannerDto> GetBanners();
}

public class BannerService : IBannerService
{
    private readonly IDataBaseContext _context;

    public BannerService(IDataBaseContext context)
    {
        _context = context;
    }

    public void AddBanner(BannerDto banner)
    {
        _context.Banners.Add(new Banner
        {
            Image = banner.Image,
            IsActive = banner.IsActive,
            Link = banner.Link,
            Name = banner.Name,
            Position = banner.Position,
            Priority = banner.Priority,
        });
        _context.SaveChanges();
    }

    public List<BannerDto> GetBanners()
    {
        var banners = _context.Banners
            .Select(p => new BannerDto
            {
                Image = p.Image,
                IsActive = p.IsActive,
                Link = p.Link,
                Name = p.Link,
                Position = p.Position,
                Priority = p.Priority,
            }).ToList();
        return banners;
    }
}


public class BannerDto
{
    [Display(Name = "نام بنر")]
    public string Name { get; set; }
    [Display(Name = "تصویر بنر")]
    public string Image { get; set; }
    [Display(Name = "لینک")]
    public string Link { get; set; }
    [Display(Name = "فعال")]
    public bool IsActive { get; set; }
    [Display(Name = "موقعیت نمایش")]
    public Position Position { get; set; }
    [Display(Name = "ترتیب نمایش")]
    public int Priority { get; set; }
}