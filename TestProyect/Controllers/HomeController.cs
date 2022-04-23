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
using TestProyect.Data;
using TestProyect.Models;


namespace TestProyect.Controllers
{

    public class HomeController : Controller
    {
        public string userExists;
        public string viewController;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
            // Busqueda del Email
            string password = "";
            var usuarioAdmin = _context.Administrativos.Where(s => s.EmailAdministrativo == email);
            var usuarioEntre = _context.Entrenadores.Where(s => s.EmailEntrenador == email);
            var usuarioJugad = _context.Jugadores.Where(s => s.EmailJugador == email);
            var usuarioUti = _context.Utileros.Where(s => s.EmailUtilero == email);
            //var usuarioTuto = _context.Tutores.Where(s => s.EmailTutor == email);
            if (usuarioAdmin.Any())
            {
                var result = _context.Administrativos.Where(s => s.EmailAdministrativo == email).Select(u => new { u.PasswordAdministrativo }).FirstOrDefault();
                password = result.PasswordAdministrativo;
            }
            else if (usuarioEntre.Any())
            {
                var result = _context.Entrenadores.Where(s => s.EmailEntrenador == email).Select(u => new { u.PasswordEntrenador }).FirstOrDefault();
                password = result.PasswordEntrenador;
            }
            else if (usuarioJugad.Any())
            {
                var result = _context.Jugadores.Where(s => s.EmailJugador == email).Select(u => new { u.PasswordJugador }).FirstOrDefault();
                password = result.PasswordJugador;
            }
            else if (usuarioUti.Any())
            {
                var result = _context.Utileros.Where(s => s.EmailUtilero == email).Select(u => new { u.PasswordUtilero }).FirstOrDefault();
                password = result.PasswordUtilero;
            }
            else
            {
                TempData["Password"] = "1";
                return View("PasswordReset");
            }


            if (password.Length > 0)
            {
                enviarEmail(email, password);
            }

            return View("Index");
        }

        //[AllowAnonymous]
        public void enviarEmail(string correo, string pass)
        {
            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("spejarproject2022@gmail.com");
            Correo.To.Add(correo);
            Correo.Subject = ("Recuperar Contraseña ");
            Correo.Body = ("Esta es la contraseña para ingresar a su cuenta:" + pass);
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
