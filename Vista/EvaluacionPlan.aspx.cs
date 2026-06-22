using PlanMejoramiento.Datos;
using PlanMejoramiento.Logica;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class EvaluacionPlan : System.Web.UI.Page
    {
        EvaluacionPlanL logica =
            new EvaluacionPlanL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (Session["IdRol"] == null)
            {
                Response.Redirect(
                    "Login.aspx");
            }

            int rol =
                Convert.ToInt32(
                    Session["IdRol"]);

            if (rol != 1 && rol != 2)
            {
                Response.Redirect(
                    "Inicio.aspx");
            }
            if (!IsPostBack)
            {
                CargarPlanes();
                Listar();
            }
        }

        private void CargarPlanes()
        {
            int rol =
                Convert.ToInt32(
                    Session["IdRol"]);

            int idUsuario =
                Convert.ToInt32(
                    Session["IdUsuario"]);

            PlanMejoramientoL l =
                new PlanMejoramientoL();

            if (rol == 1)
            {
                ddlPlan.DataSource =
                    l.Listar();
            }
            else
            {
                InstructorL instructorL =
                    new InstructorL();

                int idInstructor =
                    instructorL.ObtenerIdPorUsuario(
                        idUsuario);

                ddlPlan.DataSource =
                    l.ListarPorInstructor(
                        idInstructor);
            }

            ddlPlan.DataTextField =
                "Actividades";

            ddlPlan.DataValueField =
                "IdPlan";

            ddlPlan.DataBind();
        }

        private void Listar()
        {
            gvEvaluaciones.DataSource =
                logica.Listar();

            gvEvaluaciones.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            Modelo.EvaluacionPlan a =
                new Modelo.EvaluacionPlan();

            a.IdPlan =
                Convert.ToInt32(
                    ddlPlan.SelectedValue);

            a.Producto =
                ddlProducto.SelectedValue;

            a.Conocimiento =
                ddlConocimiento.SelectedValue;

            a.Desempeno =
                ddlDesempeno.SelectedValue;

            a.Observaciones =
                txtObservaciones.Text;

            a.FechaEvaluacion =
                DateTime.Now;

            int rol =
    Convert.ToInt32(
        Session["IdRol"]);

            if (rol == 2)
            {
                InstructorL instructorL =
                    new InstructorL();

                int idInstructor =
                    instructorL.ObtenerIdPorUsuario(
                        Convert.ToInt32(
                            Session["IdUsuario"]));

                bool esValido =
                    new PlanMejoramientoL()
                    .ValidarInstructorPlan(
                        a.IdPlan,
                        idInstructor);

                if (!esValido)
                {
                    lblMensaje.Text =
                        "No tiene permisos para evaluar este plan.";

                    return;
                }
            }

            logica.Insertar(a);

            int nuevoEstado;

            if (
                a.Producto == "Aprueba"
                &&
                a.Conocimiento == "Aprueba"
                &&
                a.Desempeno == "Aprueba")
            {
                nuevoEstado = 3;
            }
            else
            {
                nuevoEstado = 4;
            }

            PlanMejoramientoL planL =
                new PlanMejoramientoL();

            planL.ActualizarEstado(
                a.IdPlan,
                nuevoEstado);
            if (nuevoEstado == 4)
            {
                Modelo.PlanMejoramiento planOriginal =
                    planL.ObtenerPorId(
                        a.IdPlan);

                if (planOriginal.IdTipoPlan == 1)
                {
                    // Crear Plan Comité

                    Modelo.PlanMejoramiento nuevoPlan =
                        new Modelo.PlanMejoramiento();

                    nuevoPlan.FechaAsignacion =
                        DateTime.Now;

                    nuevoPlan.FechaLimite =
                        DateTime.Now.AddDays(30);

                    nuevoPlan.Actividades =
                        "Plan generado automáticamente por no aprobación.";

                    nuevoPlan.Observaciones =
                        "Escalado automáticamente a Comité.";

                    nuevoPlan.IdTipoPlan = 2;

                    nuevoPlan.IdEstadoPlan = 1;

                    nuevoPlan.IdAprendizFicha =
                        planOriginal.IdAprendizFicha;

                    nuevoPlan.IdInstructor =
                        planOriginal.IdInstructor;

                    planL.InsertarRetornandoId(
                        nuevoPlan);
                }
                else if (planOriginal.IdTipoPlan == 2)
                {
                    // Cancelar Aprendiz

                    AprendizFichaD afD =
                        new AprendizFichaD();

                    int idAprendiz =
                        afD.ObtenerAprendizPorFicha(
                            planOriginal.IdAprendizFicha);

                    AprendizD aprendizD =
                        new AprendizD();

                    aprendizD.CambiarEstado(
                        idAprendiz,
                        6); // Cancelado
                }
            }

            lblMensaje.Text =
                "Evaluación guardada correctamente.";

            Listar();
        }
    }
}