using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Vista
{
    public partial class Fichas : System.Web.UI.Page
    {

        FichaL fichaL = new FichaL();

        ProgramaL programaL = new ProgramaL();

        JornadaL jornadaL = new JornadaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarProgramas();
                CargarJornadas();
                CargarGrid();
            }
        }

        private void CargarProgramas()
        {
            ddlPrograma.DataSource =
                programaL.ObtenerProgramas();

            ddlPrograma.DataTextField =
                "Nombre";

            ddlPrograma.DataValueField =
                "IdPrograma";

            ddlPrograma.DataBind();
        }

        private void CargarJornadas()
        {
            ddlJornada.DataSource =
                jornadaL.Listar();

            ddlJornada.DataTextField =
                "NombreJornada";

            ddlJornada.DataValueField =
                "IdJornada";

            ddlJornada.DataBind();
        }

        private void CargarGrid()
        {
            gvFichas.DataSource =
                fichaL.Listar();

            gvFichas.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            Modelo.Fichas ficha = new Modelo.Fichas();

            ficha.CodigoFicha =
                txtCodigoFicha.Text;

            ficha.FechaInicio =
                Convert.ToDateTime(
                    txtFechaInicio.Text);

            ficha.FechaFinalizacion =
                Convert.ToDateTime(
                    txtFechaFinalizacion.Text);

            ficha.Descripcion =
                txtDescripcion.Text;

            ficha.Estado =
                txtEstado.Text;

            ficha.IdPrograma =
                Convert.ToInt32(
                    ddlPrograma.SelectedValue);

            ficha.IdJornada =
                Convert.ToInt32(
                    ddlJornada.SelectedValue);

            fichaL.Insertar(ficha);

            CargarGrid();

            txtCodigoFicha.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFinalizacion.Text = "";
            txtDescripcion.Text = "";
            txtEstado.Text = "";
        }

        protected void gvFichas_RowDeleting(
            object sender,
            System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    gvFichas.DataKeys[e.RowIndex].Value);

            fichaL.Eliminar(id);

            CargarGrid();
        }

        protected void gvFichas_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            GridViewRow fila =
                gvFichas.SelectedRow;

            hfIdFicha.Value =
                gvFichas.DataKeys[
                fila.RowIndex].Value.ToString();

            txtCodigoFicha.Text =
                fila.Cells[0].Text;

            txtDescripcion.Text =
                fila.Cells[2].Text;

            txtFechaInicio.Text =
                Convert.ToDateTime(
                fila.Cells[4].Text)
                .ToString("yyyy-MM-dd");

            txtFechaFinalizacion.Text =
                Convert.ToDateTime(
                fila.Cells[5].Text)
                .ToString("yyyy-MM-dd");

            txtEstado.Text =
                fila.Cells[6].Text;
        }

        protected void btnActualizar_Click(
    object sender,
    EventArgs e)
        {
            Modelo.Fichas ficha =
                new Modelo.Fichas();

            ficha.IdFicha =
                Convert.ToInt32(
                hfIdFicha.Value);

            ficha.CodigoFicha =
                txtCodigoFicha.Text;

            ficha.FechaInicio =
                Convert.ToDateTime(
                txtFechaInicio.Text);

            ficha.FechaFinalizacion =
                Convert.ToDateTime(
                txtFechaFinalizacion.Text);

            ficha.Descripcion =
                txtDescripcion.Text;

            ficha.Estado =
                txtEstado.Text;

            ficha.IdPrograma =
                Convert.ToInt32(
                ddlPrograma.SelectedValue);

            ficha.IdJornada =
                Convert.ToInt32(
                ddlJornada.SelectedValue);

            fichaL.Actualizar(ficha);

            CargarGrid();
        }
    }
}