using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MVC.Service.Identities;
using MVC.Service.Products;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace MVC.Service
{
    public static class ServiceExt
    {
        public static void AddServiceExt(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AssemblyService)));
            services.AddScoped<IProductService, ProductService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(AssemblyService)));
            services.AddScoped<IUserService, UserService>();
        }


        public static void UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var exception = exceptionFeature!.Error;


                    var result = ServiceResult.Fail(exception.Message, HttpStatusCode.InternalServerError);

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";


                    return context.Response.WriteAsJsonAsync(result);
                });
            });
        }
    }
}