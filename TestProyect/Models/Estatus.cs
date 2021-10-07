using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Estatus
    {
        [Key]
        public int IdEstatus { get; set; }

        [Required(ErrorMessage ="El Estatus es obligaotrio")]
        [Display(Name = "Estatus")]
        [StringLength(30, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string NombreEstatus { get; set; }
    }
    public class TipoUsuario
    {
        [Key]
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "El Tipo de Usuario es obligaotrio")]
        [Display(Name = "Tipo Usuario")]
        [StringLength(30, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 3)]
        public string NombreTipoUsuario { get; set; }
    }
}
