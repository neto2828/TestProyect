using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Data;

namespace TestProyect.Controllers
{
    public class CatalogosController : Controller
        
    {
        private readonly ApplicationDbContext _context;

        public CatalogosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstatusController
        public ActionResult Index()
        {
            return View();
        }

    }
}
