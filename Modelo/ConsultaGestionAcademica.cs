using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class ConsultaGestionAcademica
    {
        public int IdPlan { get; set; }

        public string CodigoFicha { get; set; }

        public string Programa { get; set; }

        public string Jornada { get; set; }

        public string Documento { get; set; }

        public string Aprendiz { get; set; }

        public string EstadoAprendiz { get; set; }

        public string TipoPlan { get; set; }

        public string EstadoPlan { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public DateTime FechaLimite { get; set; }

        public int IdInstructor { get; set; }
    }
}