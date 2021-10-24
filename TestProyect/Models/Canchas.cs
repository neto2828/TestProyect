using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Canchas
    {
        [Key]
        public int IdCancha { get; set; }

        [Display(Name = "Nombre de la Cancha")]
        [Required(ErrorMessage = "El Nombre de la Cancha es Obligatorio")]
        public string NombreCancha { get; set; }

        [Display(Name = "Latitud de la Cancha")]
        public string LatitudCancha { get; set; }

        [Display(Name = "Longitud de la Cancha")]
        public string LongitudCancha { get; set; }

        [Display(Name = "Poligono de la Cancha")]
        public string PoligonoCancha { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "El Estatus es Obligatorio")]
        public int EstatusCanchaId { get; set; }

        [ForeignKey("EstatusCanchaId")]
        public Estatus Estatus { get; set; }

    }
}
