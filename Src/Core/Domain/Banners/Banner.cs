using System.ComponentModel.DataAnnotations;

namespace Domain.Banners;

public class Banner
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
    public int Priority { get; set; }
    public Position Position { get; set; }
}

public enum Position
{
    /// <summary>
    /// اسلایدر
    /// </summary>
    [Display(Name = "اسلایدر")]
    Slider = 0,
    /// <summary>
    /// سطر اول
    /// </summary>
    [Display(Name = "سطر اول")]
    Line_1 = 1,
    /// <summary>
    /// سطر دوم
    /// </summary>
    [Display(Name = "سطر دوم")]
    Line_2 = 2,

    /// <summary>
    /// سطر سوم
    /// </summary>
    [Display(Name = " سطر سوم")]
    Line_3 = 3,
    /// <summary>
    /// سطر چهارم
    /// </summary>
    [Display(Name = "سطر چهارم")]
    Line_4 = 4,
    /// <summary>
    /// سطر پنجم
    /// </summary>
    [Display(Name = "سطر پنجم")]
    Line_5 = 5,
}