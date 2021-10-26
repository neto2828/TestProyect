using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Posiciones
    {
        [Key]
        public int IdPosicion { get; set; }

        [Display(Name = "Posición")]
        [Required(ErrorMessage = "El Nombre de la Posición es Obligatoria")]
        public string NombrePosicion { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La Ubicación es Obligatoria")]
        public String UbicacionPosicion { get; set; }

        public int EstatusPosId { get; set; }

        [ForeignKey("EstatusPosId")]
        public Estatus Estatus { get; set; }
    }
}
