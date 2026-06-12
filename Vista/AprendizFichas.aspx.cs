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
    public partial class AprendizFichas : System.Web.UI.Page
    {
        AprendizFichaL logica =
            new AprendizFichaL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAprendices();
                CargarFichas();
                Listar();
            }
        }

        private void CargarAprendices()
        {
            AprendizL aprendizL =
                new AprendizL();

            ddlAprendiz.DataSource =
                aprendizL.Listar();

            ddlAprendiz.DataTextField =
                "Nombres";

            ddlAprendiz.DataValueField =
                "IdAprendiz";

            ddlAprendiz.DataBind();
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
            Modelo.AprendizFicha af =
                new Modelo.AprendizFicha();

            af.IdAprendiz =
                Convert.ToInt32(
                    ddlAprendiz.SelectedValue);

            af.IdFicha =
                Convert.ToInt32(
                    ddlFicha.SelectedValue);

            logica.Insertar(af);

            Listar();
        }
    }
}