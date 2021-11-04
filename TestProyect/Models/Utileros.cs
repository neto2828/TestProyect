using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Utileros
    {
        [Key]
        public int IdUtilero { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "La Matrícula es Obligatoria")]
        public int MatriculaUtilero { get; set; }

        [Display(Name = "Nombre (s)")]
        [Required(ErrorMessage = "El Nombre (s) es Obligatorio")]
        public String NombreUtilero { get; set; }

        [Display(Name = "Paterno")]
        [Required(ErrorMessage = "El Apellido Paterno es Obligatorio")]
        public String PaternoUtilero { get; set; }

        [Display(Name = "Materno")]
        [Required(ErrorMessage = "El Apellido Materno es Obligatorio")]
        public String MaternoUtilero { get; set; }

        [Display(Name = "Teléfono Fijo")]
        public String CasaUtilero { get; set; }

        [Display(Name = "Teléfono Celular")]
        [Required(ErrorMessage = "El Teléfono Celular es Obligatorio")]
        public String CelularUtilero { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El Correo Electrónico es Obligatorio")]
        public String EmailUtilero { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La Contraseña es Obligatoria")]
        public String PasswordUtilero { get; set; }

        [Display(Name = "Área de Adscripción")]
        [Required(ErrorMessage = "El Área de Adscripción es Obligatorio")]
        public int AdscripcionUtiId { get; set; }
        [ForeignKey("AdscripcionUtiId")]
        public Adscripcion Adscripcion { get; set; }

        [Display(Name = "Estatus")]
        public int? EstatusUtiId { get; set; }
        [ForeignKey("EstatusUtiId")]
        public Estatus Estatus { get; set; }

        [Display(Name = "Canchas")]
        [Required(ErrorMessage = "Seleccione al menos 1 Cancha")]
        public String CanchaUtilero { get; set; }

        [Required]
        public bool ValidacionUtilero { get; set; }
        [Required]
        public bool CambioPwUtilero { get; set; }

    }
}
