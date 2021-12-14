using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class Jugadores
    {
        [Key]
        public int IdJugador { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "La Matrícula es Obligatoria")]
        public string MatriculaJugador { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string NombreJugador { get; set; }

        [Display(Name = "Paterno")]
        [Required(ErrorMessage = "El Apellido Paterno es Obligatorio")]
        public string PaternoJugador { get; set; }

        [Display(Name = "Materno")]
        [Required(ErrorMessage = "El Apellido Materno es Obligatorio")]
        public string MaternoJugador { get; set; }

        [Display(Name = "Equipo del Jugador")]
        public int EquipoJugId { get; set; }

        [ForeignKey("EquipoJugId")]
        public Equipos Equipos { get; set; }

        [Display(Name = "Estatura del Jugador")]
        [Required(ErrorMessage = "La Estatura es Obligatoria")]
        public string EstaturaJugador { get; set; }

        [Display(Name = "Peso del Jugador")]
        [Required(ErrorMessage = "El Peso es Obligatoria")]
        public string PesoJugador { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La Fecha de Nacimiento es Obligatoria")]
        public string NacimientoJugador { get; set; }

        [Display(Name = "Equipo del Jugador")]
        public int? PosicionJugId { get; set; }

        [ForeignKey("PosicionJugId")]
        public Posiciones Posiciones { get; set; }

        [Display(Name = "Teléfono Fijo")]
        public string CasaJugador { get; set; }

        [Display(Name = "Teléfono Celular")]
        [Required(ErrorMessage = "El Teléfono Celular es Obligatorio")]
        public string CelularJugador { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El Correo Electrónico es Obligatorio")]
        public string EmailJugador { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La Contraseña es Obligatoria")]
        public string PasswordJugador { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage = "La calle es Obligatoria")]
        public string CalleJugador { get; set; }

        [Display(Name = "No. Exterior")]
        [Required(ErrorMessage = "El No. Exterior es Obligatorio")]
        public string NoExtJugador { get; set; }

        [Display(Name = "No. Interior")]
        public string NoIntJugador { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "La Ciudad es Obligatoria")]
        public string CiudadJugador { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado es Obligatorio")]
        public string EstadoJugador { get; set; }

        public int? PaisJugId { get; set; }

        [ForeignKey("PaisJugId")]
        public Paises Paises { get; set; }

        public int? NacionalidadJugId { get; set; }

        [ForeignKey("NacionalidadJugId")]
        public Paises Nacionalidad { get; set; }

        [Display(Name = "Pierna Buena")]
        [Required(ErrorMessage = "La Pierna Buena es Obligatoria")]
        public string PiernaJugador { get; set; }

        [Display(Name = "Estatus")]
        public int? EstatusJugId { get; set; }

        [ForeignKey("EstatusJugId")]
        public Estatus Estatus { get; set; }

        [Required]
        public bool ValidacionJugador { get; set; }
        [Required]
        public bool CambioPwJugador { get; set; }


        public int? CamisetaJugador { get; set; }

        public string CoordenadaX { get; set; }

        public string CoordenadaY { get; set; }

        public bool TitularJugador { get; set; }
    }
}
