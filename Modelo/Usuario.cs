using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public int IdRol { get; set; }

        public bool Estado { get; set; }

        public string Rol { get; set; }
    }
}