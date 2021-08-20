using Microsoft.AspNetCore.Mvc;

namespace ArquiteturaLimpaMVC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacidade()
        {
            return View();
        }
    }
}