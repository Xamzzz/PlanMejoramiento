using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }

        public string Sigla { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}