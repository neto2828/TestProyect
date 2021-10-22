using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre de la Categoría")]
        [Required(ErrorMessage = "El Nombre de la Categoría es obligatoria")]
        public string NombreCategoria { get; set; }

        [Display(Name ="Estatus")]
        [Required(ErrorMessage ="El Estatus es Obligatorio")]
        public int EstatusCatId { get; set; }

        [ForeignKey("EstatusCatId")]
        public Estatus Estatus { get; set; }
    }
}
