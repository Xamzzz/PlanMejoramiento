using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class ProgramaL
    {
        ProgramaD datos = new ProgramaD();

        public List<Programa> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Programa p)
        {
            datos.Insertar(p);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }

        public List<Programa> ObtenerProgramas()
        {
            return datos.ObtenerProgramas();
        }

        public void Actualizar(Programa p)
        {
            datos.Actualizar(p);
        }
    }
}