using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProyect.Models;

namespace TestProyect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Estatus> Estatus { get; set; }      
       // public DbSet<Administrativos> Administrativos { get; set; }
       public DbSet<Adscripcion> Adscripcion { get; set; }

    }
}
