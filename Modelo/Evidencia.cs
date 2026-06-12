using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class Evidencia
    {
        public int IdEvidencia { get; set; }

        public string NombreArchivo { get; set; }

        public string RutaArchivo { get; set; }

        public DateTime FechaCarga { get; set; }

        public string ObservacionInstructor { get; set; }

        public int IdPlan { get; set; }

        // Mostrar en Grid
        public string Actividades { get; set; }

    }
}