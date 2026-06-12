using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Modelo
{
    public class AprendizFicha
    {
        public int IdAprendizFicha { get; set; }

        public int IdAprendiz { get; set; }

        public int IdFicha { get; set; }

        public string Aprendiz { get; set; }

        public string Ficha { get; set; }

        public string Descripcion
        {
            get
            {
                return Aprendiz +
                       " - " +
                       Ficha;
            }
        }
    }
}