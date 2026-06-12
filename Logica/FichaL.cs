using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class FichaL
    {
        FichaD datos = new FichaD();

        public List<Fichas> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Fichas f)
        {
            datos.Insertar(f);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
        public void Actualizar(Fichas f)
        {
            datos.Actualizar(f);
        }
    }
}