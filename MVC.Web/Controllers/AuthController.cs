using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Web.Controllers
{
    public class AuthController : Controller
    {
        [Authorize]
        public IActionResult Signin()
        {
            return View();
        }
    }
}