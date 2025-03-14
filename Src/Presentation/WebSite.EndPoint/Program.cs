using Application.BasketsService;
using Application.Catalogs.CatalogItems.CatalogItemPDP;
using Application.Catalogs.CatalogItems.CatalogItemServices;
using Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Catalogs.CatalogItems.UriComposer;
using Application.Catalogs.CatalogTypes.CrudService;
using Application.Catalogs.GetMenuItem;
using Application.Comments.Commands;
using Application.Discounts;
using Application.Discounts.DiscountServices;
using Application.HomePageService;
using Application.Interfaces.Contexts;
using Application.Orders;
using Application.Orders.CustomerOrdersService;
using Application.Payments;
using Application.Users;
using Application.Visitors.SaveVisitorInfo;
using Application.Visitors.VisitorOnline;
using Infrastructure.IdentityConfigs;
using Infrastructure.MappingProfile;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.MongoContext;
using WebSite.EndPoint.Hubs;
using WebSite.EndPoint.MiddleWares;
using WebSite.EndPoint.Utilities.Filters;
using WebSite.EndPoint.Utilities.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddTransient<IDataBaseContext, DatabaseContext>();
builder.Services.AddTransient<IIdentityDatabaseContext, IdentityDatabaseContext>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddDistributedSqlServerCache(option =>
{
    option.ConnectionString = connectionString;
    option.SchemaName = "dbo";
    option.TableName = "CacheData";
});

builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

builder.Services.AddMediatR(typeof(SendCommentCommand).Assembly);
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddSignalR();
builder.Services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddTransient<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
builder.Services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
builder.Services.AddTransient<IUriComposerService, UriComposerService>();
builder.Services.AddTransient<IBasketService, BasketService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICustomerOrderService, CustomerOrderService>();
builder.Services.AddTransient<IHomePageService, HomePageService>();


builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCustomExceptionHandler();
app.UseSetVisitorId();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapHub<OnlineVisitorHub>("/ChatHub");

    endpoints.MapControllerRoute(
        name: "ProductDetails",
        pattern: "product/{slug}",
        defaults: new { controller = "Product", Action = "Details" });
});


app.Run();
