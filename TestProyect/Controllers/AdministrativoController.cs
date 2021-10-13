using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        // GET: Administrativo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrativo
        public ActionResult Administrativos()
        {
            IEnumerable<Usuarios> listUsuarios = _context.Usuarios;
            return View(listUsuarios);
        }

        // GET: Administrativo
        public ActionResult Entrenadores()
        {
            return View();
        }

        // GET: Administrativo
        public ActionResult Jugadores()
        {
            return View();
        }

        public ActionResult Utileros()
        {
            return View();
        }
        public ActionResult Catalogos()
        {
            IEnumerable<Estatus> listEstatus = _context.Estatus;            
            //Tuple<Estatus, TipoUsuario> Model = new Tuple<Estatus, TipoUsuario>(new Estatus(), new TipoUsuario());
            return View(listEstatus);
        }

        [HttpGet]
        public ActionResult CrearEstatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEstatus(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                _context.Estatus.Add(estatus);
                _context.SaveChanges();
                TempData["mensaje"] = "La categoria se ha guadado";
                return RedirectToAction("Catalogos");

            }
            return View();
        }

        [HttpGet]
        public ActionResult NuevoAdministrativo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoAdministrativo(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuarios);
                _context.SaveChanges();
                TempData["mensaje"] = "El Administrativo se ha guadado";
                return RedirectToAction("Administrativos");

            }
            return View();
        }

    }
}
