using Microsoft.AspNetCore.Mvc;

namespace VisaApplicationSysWeb.Controllers.WEB
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
