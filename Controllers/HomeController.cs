using ABC_Retail_CloudPoe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ABC_Retail_CloudPoe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Specify the full relative path to the view file for CustomerMainNav
        public IActionResult CustomerMainNav()
        {
            return View("~/Views/Customer/CustomerMainNav.cshtml");
        }

        // Specify the full relative path to the view file for ProductMainNav
        public IActionResult ProductMainNav()
        {
            return View("~/Views/Product/ProductMainNav.cshtml");
        }

        // Specify the full relative path to the view file for OrderMainNav
        public IActionResult OrderMainNav()
        {
            return View("~/Views/Order/OrderMainNav.cshtml");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
