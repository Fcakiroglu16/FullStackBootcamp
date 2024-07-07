using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using MVC.Web.Models.Products;

namespace MVC.Web.Middlewares
{
    public class MiddlewareAsInterface : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);
        }
    }


    public class WhiteIpAddressMiddleware(
        RequestDelegate next,
        IOptions<IpOptions> options)
    {
        public async Task InvokeAsync(HttpContext context, [FromServices] IConfiguration configuration,
            [FromServices] IProductService productService)
        {
            if (context.Request.Path.Value!.Contains("Home/Error"))
            {
                await next.Invoke(context);
                return;
            }


            try
            {
                throw new Exception("db hatası");
                var products = productService.GetProducts();


                var productServiceFromContext = context.RequestServices.GetService<IProductService>();


                var whiteIpList = options.Value.WhiteList;


                var reqIpAddress = context.Connection.RemoteIpAddress;

                var isWhiteList = whiteIpList.Any(x => IPAddress.Parse(x).Equals(reqIpAddress));


                if (!isWhiteList)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("You are not authorized to access this resource");
                    return;
                }
            }
            catch (Exception e)
            {
                context.Response.Redirect("Home/Error");
            }


            //Request
            await next.Invoke(context);

            // response
        }
    }
}