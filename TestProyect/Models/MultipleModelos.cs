using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProyect.Models
{
    public class MultipleModelos
    {
        //public Tuple<Estatus, TipoUsuario> Es{ get; set; }
        public Estatus Estatus { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
}
}

