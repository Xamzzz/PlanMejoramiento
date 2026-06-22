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
        public int ObtenerInstructorDelPlan(
    int idPlan)
        {
            return datos.ObtenerInstructorDelPlan(
                idPlan);
        }
        public List<ConsultaGestionAcademica>
    ConsultarGestionAcademica()
        {
            return datos
                .ConsultarGestionAcademica();
        }

        public void ActualizarEstado(
    int idPlan,
    int idEstado)
        {

            datos.ActualizarEstado(
                idPlan,
                idEstado);
        }
        public Modelo.PlanMejoramiento
    ObtenerPorId(int idPlan)
        {
            return datos.ObtenerPorId(
                idPlan);
        }
        public List<Modelo.PlanMejoramiento>
    ListarPorAprendiz(
    int idAprendiz)
        {
            return datos.ListarPorAprendiz(
                idAprendiz);
        }

        public List<Modelo.PlanMejoramiento>
            ListarPorInstructor(
            int idInstructor)
        {
            return datos.ListarPorInstructor(
                idInstructor);
        }

        public bool ValidarInstructorPlan(
    int idPlan,
    int idInstructor)
        {
            return datos.ValidarInstructorPlan(
                idPlan,
                idInstructor);
        }
    }
}