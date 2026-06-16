using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class AsignacionSupervisor
    {
        public int IdAsignacionSupervisor { get; set; }

        public int IdPlan { get; set; }

        public int IdInstructorSupervisor { get; set; }

        public string Observacion { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public int IdGestionAcademica { get; set; }

        public bool Activo { get; set; }

        // Campos de consulta
        public string Aprendiz { get; set; }

        public string Instructor { get; set; }

        public string EstadoPlan { get; set; }

        public string TipoPlan { get; set; }
    }
}