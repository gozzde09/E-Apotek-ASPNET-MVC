using Microsoft.AspNetCore.Mvc;

namespace ProjeApotek.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
