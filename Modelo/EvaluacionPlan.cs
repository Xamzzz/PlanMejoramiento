using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class EvaluacionPlan
    {
        public int IdEvaluacion { get; set; }

        public string Producto { get; set; }

        public string Conocimiento { get; set; }

        public string Desempeno { get; set; }

        public string Observaciones { get; set; }

        public DateTime FechaEvaluacion { get; set; }

        public int IdPlan { get; set; }

        // Para mostrar

        public string TipoPlan { get; set; }

        public string Aprendiz { get; set; }
    }
}