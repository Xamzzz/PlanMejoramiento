using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class EstadoAprendizL
    {
        EstadoAprendizD datos =
            new EstadoAprendizD();

        public List<EstadoAprendiz> Listar()
        {
            return datos.Listar();
        }
    }
}