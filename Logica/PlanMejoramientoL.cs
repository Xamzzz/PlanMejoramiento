using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class PlanMejoramientoL
    {
        PLanMejoramientoD datos =
            new PLanMejoramientoD();

        public List<Modelo.PlanMejoramiento> Listar()
        {
            return datos.Listar();
        }

        public int InsertarRetornandoId(
            Modelo.PlanMejoramiento p)
        {
            return datos.InsertarRetornandoId(p);
        }

        public void Actualizar(
            Modelo.PlanMejoramiento p)
        {
            datos.Actualizar(p);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
    }
}