using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Data;


namespace TestProyect.Controllers
{
    public class JugadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuario = _context.Jugadores.Where(s => s.EmailJugador == email && s.PasswordJugador == password);
            if (usuario.Any())
            {
                if (usuario.Where(s => s.EmailJugador == email && s.PasswordJugador == password).Any())
                {
                    if (usuario.Where(s => s.EstatusJugId == 1).Any())
                    {
                        if (usuario.Where(s => s.ValidacionJugador == true).Any())
                        {
                            HttpContext.Session.SetString("usuariologueado", email);
                            HttpContext.Session.SetString("mainController", "Jugador");
                            return View("Index");
                        }
                        else
                        {
                            TempData["mensaje"] = "2";
                            return View("Views/Home/Index.cshtml");
                        }

                    }
                    else
                    {
                        TempData["mensaje"] = "3";
                        return View("Views/Home/Index.cshtml");
                    }
                }
                else
                {
                    TempData["mensaje"] = "1";
                    return View("Views/Home/Index.cshtml");
                }
            }
            else
            {
                TempData["mensaje"] = "1";
                return View("Views/Home/Index.cshtml");
            }
        }


        // GET: Jugadores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Jugadores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugadores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
