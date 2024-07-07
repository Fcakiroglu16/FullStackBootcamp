namespace MVC.Web.Middlewares
{
    public static class MiddlewareExt
    {
        public static void AddNotFoundMiddleware(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                //Request
                await next();
                //response
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/NotFoundPage";
                    await next();
                }
            });
        }
    }
}