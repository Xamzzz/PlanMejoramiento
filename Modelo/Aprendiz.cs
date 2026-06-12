using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class Aprendiz
    {
        public int IdAprendiz { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public int IdEstadoAprendiz { get; set; }

        public int IdUsuario { get; set; }

        public bool Activo { get; set; }

        // Para mostrar nombres en el Grid
        public string TipoDocumento { get; set; }

        public string EstadoAprendiz { get; set; }

        public string Usuario { get; set; }
    }
}