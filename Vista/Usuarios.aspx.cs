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
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuarioL usuarioL =
            new UsuarioL();

        RolL rolL =
            new RolL();

        TipoDocumentoL tipoDocumentoL =
            new TipoDocumentoL();

        EstadoAprendizL estadoAprendizL =
            new EstadoAprendizL();

        AprendizL aprendizL =
            new AprendizL();

        InstructorL instructorL =
             new InstructorL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();

                CargarTiposDocumento();
                CargarEstadosAprendiz();

                CargarGrid();
            }

      
        
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect(
                    "Login.aspx");
            }

            if (Convert.ToInt32(
                Session["IdRol"]) != 1)
            {
                Response.Redirect(
                    "Usuarios.aspx");
            }

           
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

        private void CargarRoles()
        {
            ddlRol.DataSource =
                rolL.Listar();

            ddlRol.DataTextField =
                "NombreRol";

            ddlRol.DataValueField =
                "IdRol";

            ddlRol.DataBind();
        }

        private void CargarGrid()
        {
            gvUsuarios.DataSource =
                usuarioL.Listar();

            gvUsuarios.DataBind();
        }

        protected void btnGuardar_Click(
     object sender,
     EventArgs e)
        {
            Usuario usuario =
                new Usuario();

            usuario.NombreUsuario =
                txtUsuario.Text;

            usuario.Clave =
                txtClave.Text;

            usuario.IdRol =
                Convert.ToInt32(
                    ddlRol.SelectedValue);

            int idUsuario =
                usuarioL.InsertarRetornandoId(
                    usuario);

            // Rol Aprendiz
            if (usuario.IdRol == 3)
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
                    idUsuario;

                aprendizL.Insertar(aprendiz);
            }

            // Rol Instructor
            if (usuario.IdRol == 2)
            {
                Modelo.Instructor instructor =
                    new Modelo.Instructor();

                instructor.IdTipoDocumento =
                    Convert.ToInt32(
                        ddlTipoDocumento.SelectedValue);

                instructor.NumeroDocumento =
                    txtNumeroDocumento.Text;

                instructor.Nombres =
                    txtNombres.Text;

                instructor.Apellidos =
                    txtApellidos.Text;

                instructor.Correo =
                    txtCorreo.Text;

                instructor.Telefono =
                    txtTelefono.Text;

                instructor.Especialidad =
                    txtEspecialidad.Text;

                instructor.IdUsuario =
                    idUsuario;

                InstructorL instructorL =
                    new InstructorL();

                instructorL.Insertar(instructor);
            }

            CargarGrid();

            Limpiar();
        }

        protected void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            Usuario usuario =
                new Usuario();

            usuario.IdUsuario =
                Convert.ToInt32(
                    hfIdUsuario.Value);

            usuario.NombreUsuario =
                txtUsuario.Text;

            usuario.Clave =
                txtClave.Text;

            usuario.IdRol =
                Convert.ToInt32(
                    ddlRol.SelectedValue);

            usuarioL.Actualizar(usuario);

            CargarGrid();

            Limpiar();
        }

        protected void gvUsuarios_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            GridViewRow fila =
                gvUsuarios.SelectedRow;

            hfIdUsuario.Value =
                gvUsuarios.DataKeys[
                    fila.RowIndex].Value.ToString();

            txtUsuario.Text =
                fila.Cells[1].Text;

            txtClave.Text =
                fila.Cells[2].Text;

            ddlRol.SelectedIndex =
                ddlRol.Items.IndexOf(
                    ddlRol.Items.FindByText(
                        fila.Cells[3].Text));
        }

        protected void gvUsuarios_RowDeleting(
            object sender,
            GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    gvUsuarios.DataKeys[
                        e.RowIndex].Value);

            usuarioL.Eliminar(id);

            CargarGrid();
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";

            txtNumeroDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtEspecialidad.Text = "";

            hfIdUsuario.Value = "";
        }


    }
}