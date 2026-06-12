using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class EstadoPlanL
    {
        EstadoPlanD datos =
           new EstadoPlanD();

        public List<EstadoPlan> Listar()
        {
            return datos.Listar();
        }
    }
}