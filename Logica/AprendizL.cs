using PlanMejoramiento.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class AprendizL
    {
        AprendizD datos =
            new AprendizD();

        public List<Modelo.Aprendiz> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Modelo.Aprendiz a)
        {
            datos.Insertar(a);
        }

        public void Actualizar(Modelo.Aprendiz a)
        {
            datos.Actualizar(a);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
    }
}