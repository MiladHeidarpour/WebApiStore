using Admin.EndPoint.MappingProfiles;
using Application.Banners;
using Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Application.Catalogs.CatalogItems.CatalogItemServices;
using Application.Catalogs.CatalogItems.UriComposer;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Discounts;
using Application.Discounts.AddNewDiscountService;
using Application.Discounts.DiscountServices;
using Application.Interfaces.Contexts;
using Application.Visitors.GetTodayReport;
using FluentValidation;
using Infrastructure.ExternalApi.ImageServer;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.MongoContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddDistributedSqlServerCache(option =>
{
    option.ConnectionString = connectionString;
    option.SchemaName = "dbo";
    option.TableName = "CacheData";
});

builder.Services.AddScoped<IDataBaseContext, DatabaseContext>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<IGetTodayReportService, GetTodayReportService>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();
builder.Services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<IValidator<AddNewCatalogItemDto>, AddNewCatalogItemDtoValidator>();
builder.Services.AddTransient<IImageUploadService, ImageUploadService>();
builder.Services.AddTransient<IAddNewDiscountService, AddNewDiscountService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();
builder.Services.AddTransient<IBannerService, BannerService>();

//mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));
builder.Services.AddAutoMapper(typeof(CatalogVMMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
