using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class RolL
    {
        RolD datos =
            new RolD();

        public List<Rol> Listar()
        {
            return datos.Listar();
        }
    }
}