using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.DataProtection;
using WebAndAPI.Razor.Services;
using WebAndAPI.Razor.Services.Products;

var builder = WebApplication.CreateBuilder(args);

//https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview?view=aspnetcore-8.0
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Keys")))
    .SetDefaultKeyLifetime(TimeSpan.FromDays(30));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<BackendOptions>(builder.Configuration.GetSection(BackendOptions.Backend));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ProductService>();
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