using Application.Banners;
using Domain.Banners;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly IBannerService _bannerService;
        private readonly IImageUploadService _imageUploadService;
        public CreateModel(IBannerService bannerService, IImageUploadService imageUploadService)
        {
            _bannerService = bannerService;
            _imageUploadService = imageUploadService;
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
            }
            return RedirectToPage("Index");
        }

    }
}
