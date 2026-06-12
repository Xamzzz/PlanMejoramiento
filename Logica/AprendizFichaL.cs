using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class AprendizFichaL
    {
        AprendizFichaD datos =
            new AprendizFichaD();

        public List<AprendizFicha> Listar()
        {
            return datos.Listar();
        }

        public int Guardar(AprendizFicha af)
        {
            return datos.Guardar(af);
        }

        public void Insertar(AprendizFicha af)
        {
            datos.Insertar(af);
        }
    }
}