using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class AsignacionSupervisorL
    {
        AsignacionSupervisorD datos =
            new AsignacionSupervisorD();

        public void Insertar(
    AsignacionSupervisor a)
        {
            PlanMejoramientoL planL =
                new PlanMejoramientoL();

            int instructorPlan =
                planL.ObtenerInstructorDelPlan(
                    a.IdPlan);

            if (instructorPlan ==
                a.IdInstructorSupervisor)
            {
                throw new Exception(
                    "El instructor supervisor no puede ser el mismo que creó el plan.");
            }

            datos.Insertar(a);
        }

        public List<AsignacionSupervisor> Listar()
        {
            return datos.Listar();
        }
    }
}