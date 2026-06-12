using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class JornadaL
    {
        JornadaD datos =
            new JornadaD();

        public List<Jornada> Listar()
        {
            return datos.Listar();
        }
    }
}