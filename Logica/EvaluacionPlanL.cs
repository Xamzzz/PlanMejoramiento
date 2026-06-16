using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class EvaluacionPlanL
    {
        EvaluacionPlanD dao =
            new EvaluacionPlanD();

        public void Insertar(
            EvaluacionPlan e)
        {
            dao.Insertar(e);
        }

        public List<EvaluacionPlan> Listar()
        {
            return dao.Listar();
        }
    }
}