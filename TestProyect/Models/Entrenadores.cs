using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Entrenadores
    {
        [Key]
        public int IdEntrenador { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "La Matrícula es Obligatoria")]
        public int MatriculaEntrenador { get; set; }

        [Display(Name = "Nombre (s)")]
        [Required(ErrorMessage = "El Nombre (s) es Obligatorio")]
        public String NombreEntrenador { get; set; }

        [Display(Name = "Paterno")]
        [Required(ErrorMessage = "El Apellido Paterno es Obligatorio")]
        public String PaternoEntrenador { get; set; }

        [Display(Name = "Materno")]
        [Required(ErrorMessage = "El Apellido Materno es Obligatorio")]
        public String MaternoEntrenador { get; set; }

        [Display(Name = "Teléfono Fijo")]
        public String CasaEntrenador { get; set; }

        [Display(Name = "Teléfono Celular")]
        [Required(ErrorMessage = "El Teléfono Celular es Obligatorio")]
        public String CelularEntrenador { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El Correo Electrónico es Obligatorio")]
        public String EmailEntrenador { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La Contraseña es Obligatoria")]
        public String PasswordEntrenador { get; set; }

        [Display(Name = "Área de Adscripción")]
        [Required(ErrorMessage = "El Área de Adscripción es Obligatorio")]
        public int AdscripcionEntId { get; set; }
        [ForeignKey("AdscripcionEntId")]
        public Adscripcion Adscripcion { get; set; }

        [Display(Name = "Estatus")]
        public int? EstatusEntId { get; set; }
        [ForeignKey("EstatusEntId")]
        public Estatus Estatus { get; set; }

        [Display(Name = "Categorías")]
        [Required(ErrorMessage = "Seleccione al menos 1 Categoría")]
        public String CategoriaEntrenador { get; set; }

        [Required]
        public bool ValidacionEntrenador { get; set; }
        [Required]
        public bool CambioPwEntrenador { get; set; }

    }
}
