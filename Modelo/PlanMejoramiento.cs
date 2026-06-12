using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class PlanMejoramiento
    {
        public int IdPlan { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public string Actividades { get; set; }

        public string Observaciones { get; set; }

        public DateTime FechaLimite { get; set; }

        public int IdTipoPlan { get; set; }

        public int IdEstadoPlan { get; set; }

        public int IdAprendizFicha { get; set; }

        public int IdInstructor { get; set; }

        // Campos para mostrar en GridView

        public string TipoPlan { get; set; }

        public string EstadoPlan { get; set; }

        public string Aprendiz { get; set; }

        public string Instructor { get; set; }
    }
}