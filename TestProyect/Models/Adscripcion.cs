using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Adscripcion
    {
        [Key]
        public int IdAdscripcion { get; set; }

        [Display(Name = "Nombre de la Adscripción")]
        [Required(ErrorMessage = "El Nombre de la Adscripción es obligatorio")]
        public string NombreAdscripcion { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "El Estatus es Obligatorio")]
        public int EstatusId { get; set; }

        [ForeignKey("EstatusId")]
        public Estatus Estatus { get; set; }
    }
}
