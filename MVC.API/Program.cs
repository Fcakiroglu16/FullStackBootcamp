using MVC.API.Filters;
using MVC.Repository;
using MVC.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(x =>
{
    x.Filters.Add<FluentValidationFilter>();
    x.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryExt(builder.Configuration);
builder.Services.AddServiceExt();


var app = builder.Build();

app.UseCustomExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();