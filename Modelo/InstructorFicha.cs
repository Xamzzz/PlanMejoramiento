using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class InstructorFicha
    {
        public int IdInstructorFicha { get; set; }

        public int IdInstructor { get; set; }

        public int IdFicha { get; set; }

        public string Instructor { get; set; }

        public string Ficha { get; set; }

        public string Descripcion
        {
            get
            {
                return Instructor + " - " + Ficha;
            }
        }
    }
}