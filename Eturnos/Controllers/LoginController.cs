using Microsoft.AspNetCore.Mvc;

namespace Eturnos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
