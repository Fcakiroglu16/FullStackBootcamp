using System.Reflection;
using Microsoft.Extensions.Configuration;
using WebAndAPI.Razor.Services;
using WebAndAPI.Razor.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<BackendOptions>(builder.Configuration.GetSection(BackendOptions.Backend));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient<ProductService>(options =>
{
    var backendOptions = builder.Configuration.GetSection(BackendOptions.Backend).Get<BackendOptions>();
    options.BaseAddress = new Uri(backendOptions.BaseUrl);
});


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

app.Run();