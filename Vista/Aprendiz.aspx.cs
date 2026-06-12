using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class Aprendiz : System.Web.UI.Page
    {
        AprendizL aprendizL =
            new AprendizL();

        TipoDocumentoL tipoDocumentoL =
            new TipoDocumentoL();

        EstadoAprendizL estadoAprendizL =
            new EstadoAprendizL();

        UsuarioL usuarioL =
    new UsuarioL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposDocumento();

                CargarEstadosAprendiz();

                CargarUsuarios();

                CargarGrid();
            }
        }

        private void CargarTiposDocumento()
        {
            ddlTipoDocumento.DataSource =
                tipoDocumentoL.Listar();

            ddlTipoDocumento.DataTextField =
                "Nombre";

            ddlTipoDocumento.DataValueField =
                "IdTipoDocumento";

            ddlTipoDocumento.DataBind();
        }

        private void CargarEstadosAprendiz()
        {
            ddlEstadoAprendiz.DataSource =
                estadoAprendizL.Listar();

            ddlEstadoAprendiz.DataTextField =
                "NombreEstado";

            ddlEstadoAprendiz.DataValueField =
                "IdEstadoAprendiz";

            ddlEstadoAprendiz.DataBind();
        }

        private void CargarGrid()
        {
            gvAprendiz.DataSource =
                aprendizL.Listar();

            gvAprendiz.DataBind();
        }

        protected void btnGuardar_Click(
    object sender,
    EventArgs e)
        {
            Modelo.Aprendiz aprendiz =
                new Modelo.Aprendiz();

            aprendiz.IdTipoDocumento =
                Convert.ToInt32(
                ddlTipoDocumento.SelectedValue);

            aprendiz.NumeroDocumento =
                txtNumeroDocumento.Text;

            aprendiz.Nombres =
                txtNombres.Text;

            aprendiz.Apellidos =
                txtApellidos.Text;

            aprendiz.Correo =
                txtCorreo.Text;

            aprendiz.Telefono =
                txtTelefono.Text;
            aprendiz.IdEstadoAprendiz =
                Convert.ToInt32(
                ddlEstadoAprendiz.SelectedValue);

            aprendiz.IdUsuario =
                Convert.ToInt32(
                ddlUsuario.SelectedValue);

            aprendizL.Insertar(aprendiz);

            CargarGrid();

            Limpiar();
        }

        protected void btnActualizar_Click(
    object sender,
    EventArgs e)
        {
            Modelo.Aprendiz aprendiz =
                new Modelo.Aprendiz();

            aprendiz.IdAprendiz =
                Convert.ToInt32(
                hfIdAprendiz.Value);

            aprendiz.IdTipoDocumento =
                Convert.ToInt32(
                ddlTipoDocumento.SelectedValue);

            aprendiz.NumeroDocumento =
                txtNumeroDocumento.Text;

            aprendiz.Nombres =
                txtNombres.Text;

            aprendiz.Apellidos =
                txtApellidos.Text;

            aprendiz.Correo =
                txtCorreo.Text;

            aprendiz.Telefono =
                txtTelefono.Text;

            aprendiz.IdEstadoAprendiz =
                Convert.ToInt32(
                ddlEstadoAprendiz.SelectedValue);

            aprendiz.IdUsuario =
                Convert.ToInt32(
                ddlUsuario.SelectedValue);

            aprendizL.Actualizar(aprendiz);

            CargarGrid();

            Limpiar();
        }

        protected void gvAprendiz_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            GridViewRow fila =
                gvAprendiz.SelectedRow;

            hfIdAprendiz.Value =
                gvAprendiz.DataKeys[
                fila.RowIndex].Value.ToString();

            ddlTipoDocumento.SelectedIndex =
                ddlTipoDocumento.Items.IndexOf(
                    ddlTipoDocumento.Items.FindByText(
                        fila.Cells[1].Text));

            txtNumeroDocumento.Text =
                fila.Cells[2].Text;

            txtNombres.Text =
                fila.Cells[3].Text;

            txtApellidos.Text =
                fila.Cells[4].Text;

            txtCorreo.Text =
                fila.Cells[5].Text;

            txtTelefono.Text =
                fila.Cells[6].Text;

            ddlEstadoAprendiz.SelectedIndex =
                ddlEstadoAprendiz.Items.IndexOf(
                    ddlEstadoAprendiz.Items.FindByText(
                        fila.Cells[7].Text));
        }

       
        private void Limpiar()
        {
            txtNumeroDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";

            hfIdAprendiz.Value = "";
        }

        private void CargarUsuarios()
        {
            ddlUsuario.DataSource =
                usuarioL.Listar();

            ddlUsuario.DataTextField =
                "NombreUsuario";

            ddlUsuario.DataValueField =
                "IdUsuario";

            ddlUsuario.DataBind();
        }
    }
}