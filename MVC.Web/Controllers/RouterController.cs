using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class RouterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //[Route("{page}/{pageSize}")]
        //[Route("page/{page}/pagesize/{pageSize}")]

        [Route(("page/{page}"))]
        [Route("page/{page}/pagesize/{pageSize}")]
        public IActionResult Paging(int page, int pageSize = 10)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            return View();
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [Route("{productId}")]
        public IActionResult Get2(int productId)
        {
            ViewBag.id = productId;
            return View();
        }

        [Route("{stockId?}")]
        public IActionResult GetStock(int stockId = 30)
        {
            ViewBag.stockId = stockId;
            return View();
        }
    }
}