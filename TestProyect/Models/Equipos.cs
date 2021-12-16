using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Equipos
    {
        [Key]
        public int IdEquipo { get; set; }

        [Display(Name = "Nombre Equipo")]
        [Required(ErrorMessage = "El Nombre del Equipo es Obligatorio")]
        public string NombreEquipo { get; set; }

        [Display(Name = "Entrenador del Equipo")]        
        public int? EntrenadorEquiId { get; set; }

        [ForeignKey("EntrenadorEquiId")]
        public Entrenadores Entrenadores { get; set; }

        [Display(Name = "Categoría del Equipo")]
        [Required(ErrorMessage = "La Categoría del Equipo es Obligatorio")]
        public int CategoriaEquId { get; set; }

        [ForeignKey("CategoriaEquId")]
        public Categorias Categorias { get; set; }

        [Display(Name = "Escudo del Equipo")]
        [Required(ErrorMessage = "Seleccione un Escudo para su equipo")]
        public string EscudoEquipo { get; set; }
    }
}
