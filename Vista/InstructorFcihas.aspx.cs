using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class InstructorFcihas : System.Web.UI.Page
    {
        InstructorFichaL logica =
             new InstructorFichaL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInstructor();
                CargarFichas();
                Listar();
            }
        }

        private void CargarInstructor()
        {
            InstructorL instructorL =
                new InstructorL();

            ddlInstructor.DataSource =
                instructorL.Listar();

            ddlInstructor.DataTextField =
                "Nombres";

            ddlInstructor.DataValueField =
                "IdInstructor";

            ddlInstructor.DataBind();
        }

        private void CargarFichas()
        {
            FichaL fichaL =
                new FichaL();

            ddlFicha.DataSource =
                fichaL.Listar();

            ddlFicha.DataTextField =
                "CodigoFicha";

            ddlFicha.DataValueField =
                "IdFicha";

            ddlFicha.DataBind();
        }

        private void Listar()
        {
            gvDatos.DataSource =
                logica.Listar();

            gvDatos.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            Modelo.InstructorFicha inf =
                new Modelo.InstructorFicha();

            inf.IdInstructor =
                Convert.ToInt32(
                    ddlInstructor.SelectedValue);

            inf.IdFicha =
                Convert.ToInt32(
                    ddlFicha.SelectedValue);

            logica.Insertar(inf);

            Listar();
        }
    }
}