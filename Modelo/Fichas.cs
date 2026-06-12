using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class Fichas
    {
        public int IdFicha { get; set; }

        public string CodigoFicha { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinalizacion { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }

        // FK para guardar
        public int IdPrograma { get; set; }

        public int IdJornada { get; set; }

        // Nombres para mostrar
        public string Programa { get; set; }

        public string Jornada { get; set; }
    }
}