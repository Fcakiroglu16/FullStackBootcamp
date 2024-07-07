using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class LoggingController(ILogger<LoggingController> logger, ILoggerFactory loggerFactory) : Controller
    {
        public IActionResult Index()
        {
            logger.LogError("RabbitmQ hatası");
            return View();
        }

        public IActionResult Index2([FromServices] ILogger<LoggingController> logger2)
        {
            logger2.LogError("RabbitmQ hatası");
            return View();
        }

        public IActionResult Index3()
        {
            var customLogger = loggerFactory.CreateLogger("Custom Logging Controller");
            customLogger.LogInformation("RabbitmQ hatası");
            return View();
        }
    }
}