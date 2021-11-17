using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Componentes
    {
        [Key]
        public int IdComponente { get; set; }

        [Display(Name = "Nombre del Componente")]
        [Required(ErrorMessage = "El Nombre del Componente es Obligatorio")]
        public string NombreComponente { get; set; }

        [Display(Name = "Icono del Componente")]
        [Required(ErrorMessage = "Seleccione un Icono para el componente")]
        public string IconoComponente { get; set; }


        [Required]
        public int? EntrenadorCompId { get; set; }

        [ForeignKey("EntrenadorCompId")]
        public Entrenadores Entrenadores { get; set; }


    }
}
