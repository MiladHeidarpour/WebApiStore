using Application.Banners;
using Domain.Banners;
using Infrastructure.CacheHelpers;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

namespace Admin.EndPoint.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly IBannerService _bannerService;
        private readonly IImageUploadService _imageUploadService;
        private readonly IDistributedCache _cache;
        public CreateModel(IBannerService bannerService, IImageUploadService imageUploadService, IDistributedCache cache)
        {
            _bannerService = bannerService;
            _imageUploadService = imageUploadService;
            _cache = cache;
        }


        [BindProperty]
        public BannerDto Banner { get; set; }
        [BindProperty]
        public IFormFile BannerImage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //Upload 
            var result = _imageUploadService.Upload(new List<IFormFile> { BannerImage });
            if (result.Count > 0)
            {
                Banner.Image = result.FirstOrDefault();
                _bannerService.AddBanner(Banner);

                _cache.Remove(CacheHelper.GenerateHomePageCacheKey());
            }

            return RedirectToPage("Index");
        }

    }
}
