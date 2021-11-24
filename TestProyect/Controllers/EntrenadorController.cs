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
                    if (usuario.Where(s => s.EstatusEntId == 1).Any())
                    {
                        if (usuario.Where(s => s.ValidacionEntrenador == true).Any())
                        {
                            HttpContext.Session.SetString("usuariologueado", email);
                            HttpContext.Session.SetString("mainController", "Entrenador");
                            return View("Planeacion");
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



        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Equipos.Include(i => i.Categorias);
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

        [HttpPost]
        public async Task<IActionResult> SaveCoordenadas(Array posicionJugadores )
        {
            //if (ModelState.IsValid)
           // {
           //    _context.Administrativos.Add(administrativos);
            //    await _context.SaveChangesAsync();
//TempData["mensaje"] = "El Administrativo se ha Creado";
              //  return RedirectToAction(nameof(Administrativos));
            //
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
            var TotalJugadores = _context.Jugadores.Where(i => i.EquipoJugId == id).Count();
            TempData["Equipo"] = id;
            if (TotalJugadores == 0)
            {
                TempData["TotalJugadores"] = "Este equipo No cuenta con jugadores.";
            }

            if (TotalJugadores < 11 && TotalJugadores > 0)
            {
                TempData["TotalJugadores"] = "El equipo requiere al menos 11 jugadores. Este Equipo tiene: " + TotalJugadores + " Jugadores";
            }

            if (estatu == null)
            {
                return NotFound();
            }

            return View(estatu);
        }

        public async Task<ActionResult> Planeacion(int? id)
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

            ViewData["usuariologueado"] = HttpContext.Session.GetString("usuariologueado");
            TempData["Equipo"] = id;
            return View(estatu);
        }

        public async Task<ActionResult> Estadistica(int? id)
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

            ViewData["usuariologueado"] = HttpContext.Session.GetString("usuariologueado");
            TempData["Equipo"] = id;
            return View(estatu);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers(string id)
        {
            var equipo = Int32.Parse(id);
            var jugadores = await _context.Jugadores.Where(a => a.EquipoJugId == equipo).ToListAsync();
            //if (jugadores == null) return NotFound();
            return Ok(jugadores);
        }

        public async Task<ActionResult> Jugadores(int? id)
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

            ViewData["usuariologueado"] = HttpContext.Session.GetString("usuariologueado");
            TempData["Equipo"] = id;
            return View(estatu);
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

        /***Componentes****/
        public ActionResult Configuracion()
        {
            return View();
        }


        public async Task<IActionResult> Componente()
        {
            var applicationDbContext = _context.Componentes.Where(i => i.EntrenadorCompId == 2);

            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ComponenteCreate()
        {
            return View();
        }

        // GET: EntrenadoresController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComponenteCreate(Componentes componentes)
        {
            if (ModelState.IsValid)
            {
                await _context.Componentes.AddAsync(componentes);
                await _context.SaveChangesAsync();
                int id = componentes.IdComponente;
                TempData["mensaje"] = "El Componente se ha Creado";
                return (RedirectToAction("ComponenteDetails", new { id = id }));
            }
            return View(componentes);
        }

        [HttpGet]
        public IActionResult ComponenteDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var compone = _context.Componentes.Find(id);
            if (compone == null)
            {
                return NotFound();
            }
            int componeId = compone.IdComponente;
            var prueba = _context.Componentes.Single(i => i.IdComponente == componeId);
            ViewData["ComponenteName"] = new SelectList(_context.Componentes.Where(i => i.IdComponente == componeId), "NombreComponente", "NombreComponente");
            ViewData["ComponenteId"] = new SelectList(_context.Componentes.Where(i => i.IdComponente == componeId), "IdComponente", "IdComponente");
            var applicationDbContext = _context.Componentes.Single(i => i.IdComponente == componeId);
            return View(applicationDbContext);
        }

        public IActionResult SubcomponenteCreate(int? id)
        {
            return View();
        }

        // GET: EntrenadoresController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubcomponenteCreate(int? id, Subcomponentes subcomponentes, int v)
        {
            var compone = _context.Componentes.Find(id);

            int componeId = compone.IdComponente;
            var prueba = _context.Componentes.Single(i => i.IdComponente == componeId);
            ViewData["ComponenteName"] = new SelectList(_context.Componentes.Where(i => i.IdComponente == componeId), "NombreComponente", "NombreComponente");
            ViewData["ComponenteId"] = new SelectList(_context.Componentes.Where(i => i.IdComponente == componeId), "IdComponente", "IdComponente");
            var applicationDbContext = _context.Componentes.Single(i => i.IdComponente == componeId);
            return View(applicationDbContext);
        }

        public async Task<ActionResult> Mesociclo(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = await _context.Equipos.FirstOrDefaultAsync(m => m.IdEquipo == id);
            TempData["Equipo"] = id;
            return View(estatu);
        }
        
        public IActionResult Prueba()
        {

            return View();
        }
    }
}
