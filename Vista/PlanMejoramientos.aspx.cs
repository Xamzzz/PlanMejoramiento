using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class PlanMejoramientos : System.Web.UI.Page
    {
        PlanMejoramientoL logica =
            new PlanMejoramientoL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoPlan();
                CargarEstadoPlan();
                CargarAprendizFicha();
                CargarInstructor();
                Listar();
            }
        }

        private void Listar()
        {
            gvPlanes.DataSource =
                logica.Listar();

            gvPlanes.DataBind();
        }

        private void CargarTipoPlan()
        {
            TipoPlanL l =
                new TipoPlanL();

            ddlTipoPlan.DataSource =
                l.Listar();

            ddlTipoPlan.DataTextField =
                "NombreTipo";

            ddlTipoPlan.DataValueField =
                "IdTipoPlan";

            ddlTipoPlan.DataBind();
        }

        private void CargarEstadoPlan()
        {
            EstadoPlanL l =
                new EstadoPlanL();

            ddlEstadoPlan.DataSource =
                l.Listar();

            ddlEstadoPlan.DataTextField =
                "NombreEstado";

            ddlEstadoPlan.DataValueField =
                "IdEstadoPlan";

            ddlEstadoPlan.DataBind();
        }

        private void CargarAprendizFicha()
        {
            AprendizFichaL l =
                new AprendizFichaL();

            ddlAprendizFicha.DataSource =
                l.Listar();

            ddlAprendizFicha.DataTextField =
                "Descripcion";

            ddlAprendizFicha.DataValueField =
                "IdAprendizFicha";

            ddlAprendizFicha.DataBind();
        }

        private void CargarInstructor()
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

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            Modelo.PlanMejoramiento p =
                new Modelo.PlanMejoramiento();

            p.FechaAsignacion =
                Convert.ToDateTime(
                    txtFechaAsignacion.Text);

            p.Actividades =
                txtActividades.Text;

            p.Observaciones =
                txtObservaciones.Text;

            p.FechaLimite =
                Convert.ToDateTime(
                    txtFechaLimite.Text);

            p.IdTipoPlan =
                Convert.ToInt32(
                    ddlTipoPlan.SelectedValue);

            p.IdEstadoPlan =
                Convert.ToInt32(
                    ddlEstadoPlan.SelectedValue);

            p.IdAprendizFicha =
                Convert.ToInt32(
                    ddlAprendizFicha.SelectedValue);

            p.IdInstructor =
                Convert.ToInt32(
                    ddlInstructor.SelectedValue);

            logica.InsertarRetornandoId(p);

            Listar();
        }

        protected void gvPlanes_RowCommand(
                object sender,
                GridViewCommandEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                logica.Eliminar(id);

                Listar();
            }
        }
    }
}