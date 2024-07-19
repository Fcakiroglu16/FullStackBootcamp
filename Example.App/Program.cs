using Example.App.Services;
using Example.Repository.Repositories;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
            optionsAction => { optionsAction.MigrationsAssembly("Example.Repository"); });
    }
);

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped<IArticleService, ArticleService>();

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