using ClosedXML.Excel;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using OfficeOpenXml;
using Rotativa;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Data;
using TestProyect.Models;

namespace TestProyect.Controllers
{
    public class EntrenadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntrenadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuario = _context.Entrenadores.Where(s => s.EmailEntrenador == email && s.PasswordEntrenador == password);
            if (usuario.Any())
            {
                if (usuario.Where(s => s.EmailEntrenador == email && s.PasswordEntrenador == password).Any())
                {
                    return View("Index");
                }
                else
                {
                    return Json(new { status = false, message = "Usuario Incorrecta" });
                }
            }
            else
            {
                return Json(new { status = true, message = "Clave Incorrecto" });
            }
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipos.Include(i => i.Categorias).Where(i => i.EntrenadorEquiId == 2);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult EquipoCreate()
        {
            ViewData["CategoriaEntrenador"] = new SelectList(_context.Categorias.Where(i => i.EstatusCatId == 1), "IdCategoria", "NombreCategoria");
            return View();
        }

         // GET: EntrenadoresController
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> EquipoCreate(Equipos equipos)
         {
             if (ModelState.IsValid)
             {
                 _context.Equipos.AddAsync(equipos);
                 await _context.SaveChangesAsync();
                TempData["mensaje"] = "El Equipo se ha Creado";
                return (RedirectToAction(nameof(Index)));
             }
             return View(equipos);
         }
        
        public ActionResult Field()
        {
            return View();
        }


        // POST: EntrenadoresController/Create
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

        // GET: EntrenadoresController/Edit/5
        public async Task<ActionResult> Alineacion(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = await _context.Equipos.FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        public ActionResult Planeacion()
        {
            return View();
        }

        public ActionResult Estadistica()
        {
            return View();
        }

        public ActionResult Jugadores()
        {
            return View();
        }

        public ActionResult Componente()
        {
            return View();
        }

        // GET: EntrenadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntrenadoresController/Edit/5
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

        // GET: EntrenadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntrenadoresController/Delete/5
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
