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
    public partial class GestionAcademica : System.Web.UI.Page
    {
        AsignacionSupervisorL logica =
              new AsignacionSupervisorL();

        protected void Page_Load(
     object sender,
     EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarConsultaPlanes();

                CargarPlanes();

                CargarInstructores();

                Listar();
            }
        }

        private void CargarPlanes()
        {
            PlanMejoramientoL l =
                new PlanMejoramientoL();

            ddlPlan.DataSource =
                l.Listar();

            ddlPlan.DataTextField =
                "Actividades";

            ddlPlan.DataValueField =
                "IdPlan";

            ddlPlan.DataBind();
        }

        private void CargarInstructores()
        {
            InstructorL l =
                new InstructorL();

            ddlInstructor.DataSource =
                l.Listar();

            ddlInstructor.DataTextField =
                "Nombres";

            ddlInstructor.DataValueField =
                "IdInstructor";

            ddlInstructor.DataBind();
        }

        private void Listar()
        {
            gvAsignaciones.DataSource =
                logica.Listar();

            gvAsignaciones.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                AsignacionSupervisor a =
                    new AsignacionSupervisor();

                a.IdPlan =
                    Convert.ToInt32(
                        ddlPlan.SelectedValue);

                a.IdInstructorSupervisor =
                    Convert.ToInt32(
                        ddlInstructor.SelectedValue);

                a.Observacion =
                    txtObservacion.Text;

                a.FechaAsignacion =
                    Convert.ToDateTime(
                        txtFechaAsignacion.Text);

                GestionAcademicaL gestionL =
                    new GestionAcademicaL();

                a.IdGestionAcademica =
                    gestionL.ObtenerIdPorUsuario(
                        Convert.ToInt32(
                            Session["IdUsuario"]));

                logica.Insertar(a);

                lblMensaje.Text =
                    "Asignación realizada correctamente.";

                Listar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text =
                    ex.Message;
            }
        }
        private void CargarConsultaPlanes()
        {
            PlanMejoramientoL l =
                new PlanMejoramientoL();

            gvPlanes.DataSource =
                l.ConsultarGestionAcademica();

            gvPlanes.DataBind();
        }
    }
}