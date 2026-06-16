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
    public partial class GestionAcademicaCRUD : System.Web.UI.Page
    {
        GestionAcademicaL logica =
            new GestionAcademicaL();

        TipoDocumentoL tipoDocumentoL =
            new TipoDocumentoL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposDocumento();

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

        private void CargarGrid()
        {
            gvGestionAcademica.DataSource =
                logica.Listar();

            gvGestionAcademica.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            UsuarioL usuarioL =
                new UsuarioL();

            Usuario u =
                new Usuario();

            u.NombreUsuario =
                txtNumeroDocumento.Text;

            u.Clave =
                txtNumeroDocumento.Text;

            u.IdRol = 4;

            int idUsuario =
                usuarioL.InsertarRetornandoId(u);

            Modelo.GestionAcademica g =
                new Modelo.GestionAcademica();

            g.IdTipoDocumento =
                Convert.ToInt32(
                    ddlTipoDocumento.SelectedValue);

            g.NumeroDocumento =
                txtNumeroDocumento.Text;

            g.Nombres =
                txtNombres.Text;

            g.Apellidos =
                txtApellidos.Text;

            g.Correo =
                txtCorreo.Text;

            g.Telefono =
                txtTelefono.Text;

            g.IdUsuario =
                idUsuario;

            logica.Insertar(g);

            Limpiar();

            CargarGrid();
        }

        protected void gvGestionAcademica_RowDeleting(
            object sender,
            GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    gvGestionAcademica.DataKeys[
                        e.RowIndex].Value);

            logica.Eliminar(id);

            CargarGrid();
        }

        private void Limpiar()
        {
            txtNumeroDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }
    }
}