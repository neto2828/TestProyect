using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TestProyect.Models;


namespace TestProyect.Controllers
{

    public class HomeController : Controller
    {
        public string userExists;
        public string viewController;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            userExists = HttpContext.Session.GetString("usuariologueado");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuariologueado")))
            {
                return View("Views/Home/Index.cshtml");
            }
            else
            {
                viewController = HttpContext.Session.GetString("mainController");
                return View("Views/Administrativo/Index.cshtml");

            }

        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("usuariologueado", "");
            return View("Views/Home/Index.cshtml");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Amigo()
        {
            return View();
        }

        public IActionResult PasswordReset()
        {
            return View();
        }

        public IActionResult Administracion()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
