using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Mesociclos
    {
        [Key]
        public int IdMesociclo { get; set; }

        [Display(Name = "Volumen")]
        [Required(ErrorMessage = "Ingrese el Volumen en Minutos")]
        public int VolumenMesociclo { get; set; }

        [Display(Name = "Turno")]
        [Required(ErrorMessage = "Seleccione el Turno de la Actividad")]
        public int TurnoMesococlo { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Fecha de la Actividad")]
        public DateTime FechaMesococlo { get; set; }


        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Observaciones de la Actividad")]
        public string ObservacionesMesococlo { get; set; }

        [Display(Name = "Lugar")]
        [Required(ErrorMessage = "Seleccione el lugar de la Actividad")]
        public int? MesocicloCanId { get; set; }
        [ForeignKey("MesocicloCanId")]
        public Canchas Canchas { get; set; }

       
        public int? MesocicloEquId { get; set; }
        [ForeignKey("MesocicloEquId")]
        public Equipos Equipos { get; set; }

        public int? MesocicloCompId { get; set; }
        [ForeignKey("MesocicloCompId")]
        public Componentes Componentes { get; set; }


    }
}
