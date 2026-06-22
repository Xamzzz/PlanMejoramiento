using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class Evidencias : System.Web.UI.Page
    {
        EvidenciaL logica =
            new EvidenciaL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            int rol =
    Convert.ToInt32(
        Session["IdRol"]);
            if (rol == 3)
            {
                ddlPlan.Visible = false;

                txtObservacion.Visible = false;

                lblObservacion.Visible = false;
            }
            if (rol == 2)
            {
                fuArchivo.Visible = false;

                txtNombreArchivo.Visible = false;

                lblNombreArchivo.Visible = false;

                lblArchivo.Visible = false;
            }
            if (rol == 4)
            {
                btnGuardar.Visible = false;

                fuArchivo.Visible = false;

                txtNombreArchivo.Visible = false;

                txtObservacion.Visible = false;

                ddlPlan.Visible = false;
            }
            if (!IsPostBack)
            {
                CargarPlanes();
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

        private void Listar()
        {
            int rol =
                Convert.ToInt32(
                    Session["IdRol"]);

            int idUsuario =
                Convert.ToInt32(
                    Session["IdUsuario"]);

            // ADMINISTRADOR
            if (rol == 1)
            {
                gvEvidencias.DataSource =
                    logica.Listar();
            }

            // INSTRUCTOR
            else if (rol == 2)
            {
                InstructorL instructorL =
                    new InstructorL();

                int idInstructor =
                    instructorL.ObtenerIdPorUsuario(
                        idUsuario);

                gvEvidencias.DataSource =
                    logica.ListarPorInstructor(
                        idInstructor);
            }

            // APRENDIZ
            else if (rol == 3)
            {
                AprendizL aprendizL =
                    new AprendizL();

                int idAprendiz =
                    aprendizL.ObtenerIdPorUsuario(
                        idUsuario);

                gvEvidencias.DataSource =
                    logica.ListarPorAprendiz(
                        idAprendiz);
            }

            // GESTIÓN ACADÉMICA
            else if (rol == 4)
            {
                gvEvidencias.DataSource =
                    logica.Listar();
            }

            gvEvidencias.DataBind();
        }

        protected void btnGuardar_Click(
     object sender,
     EventArgs e)
        {
            string rutaArchivo = "";

            if (fuArchivo.HasFile)
            {
                string nombreArchivo =
                    fuArchivo.FileName;

                string rutaFisica =
                    Server.MapPath("~/Evidencias/")
                    + nombreArchivo;

                fuArchivo.SaveAs(rutaFisica);

                rutaArchivo =
                    "~/Evidencias/" +
                    nombreArchivo;
            }

            Modelo.Evidencia ev =
                new Modelo.Evidencia();

            ev.NombreArchivo =
                txtNombreArchivo.Text;

            ev.RutaArchivo =
                rutaArchivo;

            ev.ObservacionInstructor =
                txtObservacion.Text;

            ev.IdPlan =
                Convert.ToInt32(
                    ddlPlan.SelectedValue);

            logica.Insertar(ev);

            Listar();
        }

        protected void gvEvidencias_RowDeleting(
    object sender,
    GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    gvEvidencias.DataKeys[e.RowIndex].Value);

            logica.Eliminar(id);

            Listar();
        }
    }
}