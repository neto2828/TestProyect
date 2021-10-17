using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Data;
using TestProyect.Models;

namespace TestProyect.Controllers
{
    public class CatalogosController : Controller

    {
        private readonly ApplicationDbContext _context;

        public CatalogosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*Controlador Catalogo Index*/
        public IActionResult Index()
        {
            return View();
        }
        /***************************/

        /*Controlador CRUD Estatus Index*/
        [HttpGet]
        public async Task<IActionResult> Estatus()
        {
            return View(await _context.Estatus.ToListAsync());
        }

        [HttpGet]
        public IActionResult EstatusCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EstatusCreate(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                _context.Estatus.Add(estatus);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "El Estatus se ha Creado";
                return RedirectToAction(nameof(Estatus));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EstatusEdit(int? id)
        {
            if(id==null || id== 0)
            {
                return NotFound();
            }
            var estatu = _context.Estatus.Find(id);
            if(estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EstatusEdit(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                _context.Estatus.Update(estatus);
                await _context.SaveChangesAsync();
                TempData["actualizacion"] = "El Estatus se ha Modificado";
                return RedirectToAction(nameof(Estatus));
            }
            return View(estatus);
        }

        [HttpGet]
        public IActionResult EstatusDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Estatus.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpGet]
        public IActionResult EstatusDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Estatus.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpPost, ActionName("EstatusDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EstatusDeleteR(int? id)
        {
            var estatu = await _context.Estatus.FindAsync(id);

            if(estatu == null)
            {
                return View();
            }            
                _context.Estatus.Remove(estatu);
                await _context.SaveChangesAsync();
                TempData["eliminado"] = "El Estatus se ha Eliminado";
                return RedirectToAction(nameof(Estatus));            
        }
        /***************************/
        /*Controlador CRUD Adscripcion Index*/
        [HttpGet]
        public async Task<IActionResult> Adscripcion()
        {
            var applicationDbContext = _context.Adscripcion.Include(i => i.Estatus);
            return View(await applicationDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult AdscripcionCreate()
        {
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdscripcionCreate(Adscripcion adscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Adscripcion.Add(adscripcion);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "La Adscripción se ha Creado";
                return RedirectToAction(nameof(Adscripcion));
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdscripcionEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Adscripcion.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            return View(estatu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdscripcionEdit(Adscripcion adscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Adscripcion.Update(adscripcion);
                await _context.SaveChangesAsync();
                TempData["actualizacion"] = "La Adscripción se ha Modificado";
                return RedirectToAction(nameof(Adscripcion));
            }
            return View(adscripcion);
        }
        [HttpGet]
        public async Task<IActionResult> AdscripcionDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = await _context.Adscripcion.Include(i => i.Estatus).FirstOrDefaultAsync(m => m.IdAdscripcion == id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpGet]
        public IActionResult AdscripcionDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Adscripcion.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpPost, ActionName("AdscripcionDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdscripcionDeleteR(int? id)
        {
            var estatu = await _context.Adscripcion.FindAsync(id);
            if (estatu == null)
            {
                return View();
            }

            _context.Adscripcion.Remove(estatu);
            await _context.SaveChangesAsync();
            TempData["eliminado"] = "El Estatus se ha Eliminado";
            return RedirectToAction(nameof(Adscripcion));
        }
        /***************************/
    }
}
