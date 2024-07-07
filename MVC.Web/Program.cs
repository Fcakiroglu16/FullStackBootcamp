using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using MVC.Web.Filters;
using MVC.Web.Middlewares;
using MVC.Web.Models.Categories;
using MVC.Web.Models.Products;
using MVC.Web.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<IpOptions>(builder.Configuration.GetSection("IpOptions"));
// Add services to the container.
builder.Services.AddControllersWithViews();

// virtual path/ reference path
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.AddScoped<HasProductFilter>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSingleton<ProductHelper>();

// DI Container Framework ICategoryRepository > CategoryRepository instance =>
// singleton
// scoped
//transient
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("/Views/PartialViews/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Views/ViewComponents/{0}" + RazorViewEngine.ViewExtension);
});
//builder.Services.AddAuthorization(configure =>
//{
//    configure.AddPolicy("defaultPolicy", x => { x.RequireClaim("x-device", "web"); });
//});
var app = builder.Build();


app.AddNotFoundMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseMiddleware<WhiteIpAddressMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();


#region Middleware Examples

//app.MapWhen(context => !context.Request.Path.Value.Contains("Home/Error"),
//    mapWhenApp => { mapWhenApp.Run(context => context.Response.WriteAsync("MapWhen Example Middleware\n")); });


//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("1. middleware request\n");

//    await next();

//    await context.Response.WriteAsync("1. middleware response\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("2. middleware request\n");

//    await next();

//    await context.Response.WriteAsync("2. middleware response\n");
//});

//app.Run(async (context) => { await context.Response.WriteAsync("Terminal middleware response\n"); });


//app.MapWhen(context => context.Request.Query.ContainsKey("Name"),
//    mapWhenApp => { mapWhenApp.Run(context => context.Response.WriteAsync("MapWhen Example Middleware\n")); });


//app.Map("/example-middleware",
//    appMiddleware =>
//    {
//        appMiddleware.Run(context => { return context.Response.WriteAsync("Example Middleware\n"); });
//    }); 

#endregion


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}"
);
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id:int}"
);

app.MapControllerRoute(
    name: "default2",
    pattern: "{controller=Home}/{action=Index}/{id:int}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");


app.Run();