using Microsoft.AspNetCore.Mvc;

namespace VisaApplicationSysWeb.Controllers.WEB
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string successMessage = TempData["SuccessMessage"] as string;
            ViewBag.SuccessMessage = successMessage;
            return View();
        }
    }
}
