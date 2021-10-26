using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Paises
    {
        [Key]
        public int IdPais { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El Nombre del País es Obligatorio")]
        public string NombrePais { get; set; }

        [Required]
        public string ClasePais { get; set; }
    }
}
