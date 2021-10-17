using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Estatus
    {
        [Key]        
        public int IdEstatus { get; set; }

        [Display(Name ="Nombre Estatus")]
        [Required(ErrorMessage ="El Nombre del Estatus es obligatorio")]
        public String NombreEstatus { get; set; }

    }
}
