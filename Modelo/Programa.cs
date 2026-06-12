using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class Programa
    {
        public int IdPrograma { get; set; }

        public string CodigoPrograma { get; set; }

        public string Nombre { get; set; }

        public string Version { get; set; }

        public string Nivel { get; set; }

        public int Duracion { get; set; }

        public bool Estado { get; set; }
    }
}