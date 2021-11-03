using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Administrativos
    {
        [Key]
        public int IdAdministrativos { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "La Matrícula es Obligatoria")]
        public int MatriculaAdministrativo { get; set; }

        [Display(Name = "Nombre (s)")]
        [Required(ErrorMessage = "El Nombre (s) es Obligatorio")]
        public String NombreAdministrativo { get; set; }

        [Display(Name = "Paterno")]
        [Required(ErrorMessage = "El Apellido Paterno es Obligatorio")]
        public String PaternoAdministrativo { get; set; }

        [Display(Name = "Materno")]
        [Required(ErrorMessage = "El Apellido Materno es Obligatorio")]
        public String MaternoAdministrativo { get; set; }

        [Display(Name = "Teléfono Fijo")]
        public String CasaAdministrativo { get; set; }

        [Display(Name = "Teléfono Celular")]
        [Required(ErrorMessage = "El Teléfono Celular es Obligatorio")]
        public String CelularAdministrativo { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El Correo Electrónico es Obligatorio")]
        public String EmailAdministrativo { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La Contraseña es Obligatoria")]
        public String PasswordAdministrativo { get; set; }

        [Display(Name = "Área de Adscripción")]
        [Required(ErrorMessage = "El Área de Adscripción es Obligatorio")]
        public int AdscripcionAdminId { get; set; }
        [ForeignKey("AdscripcionAdminId")]
        public Adscripcion Adscripcion { get; set; }


        [Display(Name = "Estatus")]
        public int? IdEstatus { get; set; }
        [ForeignKey("IdEstatus")]
        public Estatus Estatus { get; set; }


        [Required]
        public bool ValidacionAdministrativo { get; set; }
        [Required]
        public bool CambioPwAdministrativo { get; set; }

        internal void createTableInstance()
        {
            throw new NotImplementedException();
        }
    }
}
