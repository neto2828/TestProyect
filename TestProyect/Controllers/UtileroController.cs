using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Data;
using TestProyect.Models;

namespace TestProyect.Controllers
{
    public class UtileroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtileroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuario = _context.Utileros.Where(s => s.EmailUtilero == email && s.PasswordUtilero == password);
            if (usuario.Any())
            {
                if (usuario.Where(s => s.EmailUtilero == email && s.PasswordUtilero == password).Any())
                {
                    if (usuario.Where(s => s.EstatusUtiId == 1).Any())
                    {
                        if (usuario.Where(s => s.ValidacionUtilero == true).Any())
                        {
                            HttpContext.Session.SetString("usuariologueado", email);
                            HttpContext.Session.SetString("mainController", "Utilero");
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

        // GET: Utileros
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utileros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utileros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utileros/Create
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

        // GET: Utileros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utileros/Edit/5
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

        // GET: Utileros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utileros/Delete/5
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
