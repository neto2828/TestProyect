using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Subcomponentes
    {

        [Key]
        public int IdSubcomponente { get; set; }

        [Display(Name = "Nombre Subcomponente")]
        [Required(ErrorMessage = "El Nombre del Subcomponente es Obligatorio")]
        public string NombreSubcomponente { get; set; }

        [Display(Name = "Entrenador del Equipo")]
        [Required]
        public int? ComponenteSubId { get; set; }

        [ForeignKey("ComponenteSubId")]
        public Componentes Componentes { get; set; }
    }
}
