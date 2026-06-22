using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class InstructorL
    {
        InstructorD datos =
           new InstructorD();

        public List<Instructor> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Instructor i)
        {
            datos.Insertar(i);
        }

        public void Actualizar(Instructor i)
        {
            datos.Actualizar(i);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }

        public int ObtenerIdPorUsuario(
    int idUsuario)
        {
            return datos.ObtenerIdPorUsuario(
                idUsuario);
        }
    }
}