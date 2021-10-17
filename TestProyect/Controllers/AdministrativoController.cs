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
        
    }
}
