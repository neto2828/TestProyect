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

    public class AdministrativoController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public AdministrativoController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*Controlador CRUD Administrativo Index*/
        public ActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Administrativos()
        {
            var applicationDbContext = _context.Administrativos.Include(i => i.Estatus).Include(i => i.Adscripcion);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult AdministrativosCreate()
        {
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdministrativosCreate(Administrativos administrativos)
        {
            if (ModelState.IsValid)
            {
                _context.Administrativos.Add(administrativos);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "El Administrativo se ha Creado";
                return RedirectToAction(nameof(Administrativos));
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdministrativosEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Administrativos.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View(estatu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdministrativosEdit(Administrativos administrativos)
        {
            if (ModelState.IsValid)
            {
                _context.Administrativos.Update(administrativos);
                await _context.SaveChangesAsync();
                TempData["actualizacion"] = "El Administrativo se ha Modificado";
                return RedirectToAction(nameof(Administrativos));
            }
            return View(administrativos);
        }

        [HttpGet]
        public async Task<IActionResult> AdministrativosDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = await _context.Administrativos.Include(i => i.Estatus).Include(i => i.Adscripcion).FirstOrDefaultAsync(m => m.IdAdministrativos == id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpGet]
        public IActionResult AdministrativosDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Administrativos.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View(estatu);
        }

        [HttpPost, ActionName("AdministrativosDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdministrativosDeleteR(int? id)
        {
            var estatu = await _context.Administrativos.FindAsync(id);
            if (estatu == null)
            {
                return View();
            }

            _context.Administrativos.Remove(estatu);
            await _context.SaveChangesAsync();
            TempData["eliminado"] = "El Administrativo se ha Eliminado";
            return RedirectToAction(nameof(Administrativos));
        }

        public IActionResult ExportToPDFAdministrativo()
        {
            List<Administrativos> administrativos = new List<Administrativos>();
            return View();
        }

        public IActionResult ExportToExcelAdministrativo()
        {            
            using(var wokbook = new XLWorkbook())
            {
                var worksheet = wokbook.Worksheets.Add("Administrativos");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Matrícula";
                worksheet.Cell(currentRow, 2).Value = "Nombre (s)";
                worksheet.Cell(currentRow, 3).Value = "Paterno";
                worksheet.Cell(currentRow, 4).Value = "Materno";
                worksheet.Cell(currentRow, 5).Value = "Teléfono Fijo";
                worksheet.Cell(currentRow, 6).Value = "Teléfono Celular";
                worksheet.Cell(currentRow, 7).Value = "Correo Electrónico";
                worksheet.Cell(currentRow, 8).Value = "Área de Adscripción";
                worksheet.Cell(currentRow, 9).Value = "Estatus";
                foreach (var des in _context.Administrativos.Include(i => i.Estatus).Include(i => i.Adscripcion))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = des.MatriculaAdministrativo;
                    worksheet.Cell(currentRow, 2).Value = des.NombreAdministrativo;
                    worksheet.Cell(currentRow, 3).Value = des.PaternoAdministrativo;
                    worksheet.Cell(currentRow, 4).Value = des.MaternoAdministrativo;
                    worksheet.Cell(currentRow, 5).Value = des.CasaAdministrativo;
                    worksheet.Cell(currentRow, 6).Value = des.CelularAdministrativo;
                    worksheet.Cell(currentRow, 7).Value = des.EmailAdministrativo;
                    worksheet.Cell(currentRow, 8).Value = des.Adscripcion.NombreAdscripcion;
                    worksheet.Cell(currentRow, 9).Value = des.Estatus.NombreEstatus;
                }
                using (var stream = new MemoryStream())
                {
                    wokbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Administrativos.xlsx");
                }
            }
        }

        [HttpGet]
        public IActionResult AdministrativoUpload()
        {
            return View();
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdministrativoUpload(IFormFile batchUsers)
        {
            if (ModelState.IsValid)
            {
                if (batchUsers?.Length > 0)
                {
                    // convert to a stream
                    var stream = batchUsers.OpenReadStream();
                    List<Administrativos> administrativos = new List<Administrativos>();
                    try
                    {
                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets.First();
                            var rowCount = worksheet.Dimension.Rows;

                            for (var row = 2; row <= rowCount; row++)
                            {
                                try
                                {
                                    var nombre = worksheet.Cells[row, 1].Value?.ToString();
                                    var paterno = worksheet.Cells[row, 2].Value?.ToString();
                                    var materno = worksheet.Cells[row, 3].Value?.ToString();

                                    var admin = new Administrativos()
                                    {
                                        NombreAdministrativo = nombre,
                                        PaternoAdministrativo = paterno,
                                        MaternoAdministrativo = materno
                                    };

                                    administrativos.Add(admin);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        return View("Administrativos", administrativos);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return View();
        }*/

        /***************************/
        /*Controlador CRUD Entrenadores Index*/
        public async Task<IActionResult> Entrenadores()
        {
            var applicationDbContext = _context.Entrenadores.Include(i => i.Estatus).Include(i => i.Adscripcion);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult EntrenadoresCreate()
        {

            ViewData["CategoriaEntrenador"] = new SelectList(_context.Categorias.Where(i => i.EstatusCatId == 1), "IdCategoria", "NombreCategoria");
            ViewData["EstatusEntId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionEntId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntrenadoresCreate(Entrenadores entrenadores)
        {
            if (ModelState.IsValid)
            {
                _context.Entrenadores.Add(entrenadores);
                await _context.SaveChangesAsync();
               TempData["mensaje"] = "El Entrenador se ha Creado";
                return RedirectToAction(nameof(Entrenadores));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EntrenadoresEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Entrenadores.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View(estatu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntrenadoresEdit(Entrenadores entrenadores)
        {
            if (ModelState.IsValid)
            {
                _context.Entrenadores.Update(entrenadores);
                await _context.SaveChangesAsync();
                TempData["actualizacion"] = "El Entrenador se ha Modificado";
                return RedirectToAction(nameof(Entrenadores));
            }
            return View(entrenadores);
        }

        [HttpGet]
        public async Task<IActionResult> EntrenadoresDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = await _context.Entrenadores.Include(i => i.Estatus).Include(i => i.Adscripcion).FirstOrDefaultAsync(m => m.IdEntrenador == id);
            if (estatu == null)
            {
                return NotFound();
            }
            return View(estatu);
        }

        [HttpGet]
        public IActionResult EntrenadoresDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var estatu = _context.Entrenadores.Find(id);
            if (estatu == null)
            {
                return NotFound();
            }
            ViewData["EstatusId"] = new SelectList(_context.Estatus, "IdEstatus", "NombreEstatus");
            ViewData["AdscripcionId"] = new SelectList(_context.Adscripcion.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View(estatu);
        }

        [HttpPost, ActionName("EntrenadoresDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EntrenadoresDeleteR(int? id)
        {
            var estatu = await _context.Entrenadores.FindAsync(id);
            if (estatu == null)
            {
                return View();
            }

            _context.Entrenadores.Remove(estatu);
            await _context.SaveChangesAsync();
            TempData["eliminado"] = "El Entrenador se ha Eliminado";
            return RedirectToAction(nameof(Entrenadores));
        }


        public IActionResult ExportToExcelEntrenadores()
        {
            using (var wokbook = new XLWorkbook())
            {
                var worksheet = wokbook.Worksheets.Add("Entrenadores");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Matrícula";
                worksheet.Cell(currentRow, 2).Value = "Nombre (s)";
                worksheet.Cell(currentRow, 3).Value = "Paterno";
                worksheet.Cell(currentRow, 4).Value = "Materno";
                worksheet.Cell(currentRow, 5).Value = "Teléfono Fijo";
                worksheet.Cell(currentRow, 6).Value = "Teléfono Celular";
                worksheet.Cell(currentRow, 7).Value = "Correo Electrónico";
                worksheet.Cell(currentRow, 8).Value = "Área de Adscripción";
                worksheet.Cell(currentRow, 9).Value = "Estatus";
                worksheet.Cell(currentRow, 9).Value = "Categorías";
                foreach (var des in _context.Entrenadores.Include(i => i.Estatus).Include(i => i.Adscripcion))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = des.MatriculaEntrenador;
                    worksheet.Cell(currentRow, 2).Value = des.NombreEntrenador;
                    worksheet.Cell(currentRow, 3).Value = des.PaternoEntrenador;
                    worksheet.Cell(currentRow, 4).Value = des.MaternoEntrenador;
                    worksheet.Cell(currentRow, 5).Value = des.CasaEntrenador;
                    worksheet.Cell(currentRow, 6).Value = des.CelularEntrenador;
                    worksheet.Cell(currentRow, 7).Value = des.EmailEntrenador;
                    worksheet.Cell(currentRow, 8).Value = des.Adscripcion.NombreAdscripcion;
                    worksheet.Cell(currentRow, 9).Value = des.Estatus.NombreEstatus;
                    worksheet.Cell(currentRow, 7).Value = des.CategoriaEntrenador;
                }
                using (var stream = new MemoryStream())
                {
                    wokbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Entrenadores.xlsx");
                }
            }
        }

        /***************************/
        /*Controlador CRUD Jugadores Index*/

        public async Task<IActionResult> Jugadores()
        {
            var applicationDbContext = _context.Jugadores.Include(i => i.Estatus);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult JugadoresCreate()
        {

            //ViewData["CategoriaEntrenador"] = new SelectList(_context.Categorias.Where(i => i.EstatusCatId == 1), "IdCategoria", "NombreCategoria");
            ViewData["Nacionalidad"] = new SelectList(_context.Paises, "IdPais", "NombrePais");
            //ViewData["Nacionalidad"] = new SelectList(_context.Paises.Where(i => i.EstatusId == 1), "IdAdscripcion", "NombreAdscripcion");
            return View();
        }



        /***************************/
    }
}
