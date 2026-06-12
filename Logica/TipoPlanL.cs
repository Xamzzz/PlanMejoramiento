using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class TipoPlanL
    {
        TipoPlanD datos =
            new TipoPlanD();

        public List<TipoPlan> Listar()
        {
            return datos.Listar();
        }
    }
}