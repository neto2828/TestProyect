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
using System.Net.Mail;
using System.Net;
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
                string vista = "Views/" + viewController + "/Index.cshtml";
                return View(vista);

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
            viewController = HttpContext.Session.GetString("mainController");

            return View(viewController);
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

        [HttpPost]
        public ActionResult Recuperar(string email)
        {
            //


            //
            enviarEmail( email , "1234567");
            return View("Index");
        }

        //[AllowAnonymous]
        public void enviarEmail(string correo, string pass)
        {
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("spejarproject2022@gmail.com");
            Correo.To.Add(correo);
            Correo.Subject = ("Recuperar Contraseña ");
            Correo.Body = ("Esta es la contraseña " + pass);
            Correo.Priority = MailPriority.High;

            SmtpClient ServerMail = new SmtpClient();
            ServerMail.Host = "smtp.gmail.com";
            ServerMail.Port = (587);
            //ServerMail.Credentials = CredentialCache.DefaultNetworkCredentials;
            ServerMail.Credentials = new NetworkCredential("spejarproject2022@gmail.com", "Unideh123*");
            ServerMail.UseDefaultCredentials = false;
            ServerMail.EnableSsl = true;

            try
            {
                ServerMail.Send(Correo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
