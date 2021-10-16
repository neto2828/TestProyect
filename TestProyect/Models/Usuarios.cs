using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El Nombre es obligaotrio")]
        [Display(Name = "Nombre (s)")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es obligaotrio")]
        [Display(Name = "Apellido Paterno")]
        public string PaternoUsuario { get; set; }

        [Required(ErrorMessage = "El Apellido Materno es obligaotrio")]
        [Display(Name = "Apellido Materno")]
        public string MaternoUsuario { get; set; }

        [Required(ErrorMessage = "El Teléfono Celular es obligaotrio")]
        [Display(Name = "Teléfono Celular")]
        public string CelularUsuario { get; set; }

        [Required(ErrorMessage = "El Email es obligaotrio")]
        [Display(Name = "Email")]
        public string EmailUsuario { get; set; }

        public string PasswordUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        public int IdEstatus { get; set; }

    }
}
