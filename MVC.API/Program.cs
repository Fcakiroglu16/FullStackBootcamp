using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MVC.API;
using MVC.API.Filters;
using MVC.Repository;
using MVC.Repository.Data;
using MVC.Repository.Identities;
using MVC.Service;
using MVC.Service.Identities;
using MVC.Service.Identities.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(x =>
{
    x.Filters.Add<FluentValidationFilter>();
    x.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7135")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddRepositoryExt(builder.Configuration);
builder.Services.AddServiceExt();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    //options.Password.RequiredUniqueChars=
    options.Password.RequiredLength = 4;
}).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<ClientCredentialsOption>(builder.Configuration.GetSection("ClientCredentialsOption"));

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;


    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("x-version"), new HeaderApiVersionReader("x-version"),
        new UrlSegmentApiVersionReader()
    );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});


#region OPenTelemetry

builder.Services.AddOpenTelemetry().WithTracing(options =>
{
    options.ConfigureResource(x => { x.AddService("MVC.API", serviceVersion: "1.0"); });


    options.AddAspNetCoreInstrumentation(configure =>
    {
        configure.Filter = (httpContext) => httpContext.Request.Path.Value!.Contains("api");
    });
    options.AddEntityFrameworkCoreInstrumentation(configure =>
    {
        configure.SetDbStatementForText = true;
        configure.SetDbStatementForStoredProcedure = true;

        configure.EnrichWithIDbCommand = (activity, command) =>
        {
            //list sql parameters

            foreach (var parameter in command.Parameters)
            {
                var sqlParameter = parameter as SqlParameter;

                if (sqlParameter is not null)
                {
                    activity.AddTag(sqlParameter!.ParameterName, sqlParameter!.Value);
                }
            }
        };
    });
    options.AddHttpClientInstrumentation();
    options.AddOtlpExporter().AddConsoleExporter();
}).WithLogging(cfg =>
{
    cfg.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("MVC.API", serviceVersion: "1.0"));
    cfg.AddOtlpExporter();
});

#endregion


#region Token Validation

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    var tokenOption = (builder.Configuration.GetSection("TokenOption").Get<TokenOption>())!;


    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenOption.Issuer,
        ValidateIssuer = false,
        ValidAudience = tokenOption.Audience,
        ValidateAudience = false,
        ValidateLifetime = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SignatureKey)),
        ValidateIssuerSigningKey = false
    };
}).AddJwtBearer("clientCredentialSchema", options =>
{
    var tokenOption = (builder.Configuration.GetSection("TokenOption").Get<TokenOption>())!;


    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenOption.Issuer,
        ValidateIssuer = false,
        ValidAudience = tokenOption.Audience,
        ValidateAudience = false,
        ValidateLifetime = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SignatureKey)),
        ValidateIssuerSigningKey = false
    };
});

#endregion


var app = builder.Build();

app.UseCustomExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();