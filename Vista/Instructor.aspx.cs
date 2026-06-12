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
    public partial class Instructor : System.Web.UI.Page
    {
        InstructorL instructorL =
            new InstructorL();

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
            gvInstructores.DataSource =
                instructorL.Listar();

            gvInstructores.DataBind();
        }

        protected void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            Modelo.Instructor i =
                new Modelo.Instructor();

            i.IdInstructor =
                Convert.ToInt32(
                    hfIdInstructor.Value);

            i.IdTipoDocumento =
                Convert.ToInt32(
                    ddlTipoDocumento.SelectedValue);

            i.NumeroDocumento =
                txtNumeroDocumento.Text;

            i.Nombres =
                txtNombres.Text;

            i.Apellidos =
                txtApellidos.Text;

            i.Correo =
                txtCorreo.Text;

            i.Telefono =
                txtTelefono.Text;

            i.Especialidad =
                txtEspecialidad.Text;

       

            i.IdUsuario =
            Convert.ToInt32(
                hfIdUsuario.Value);

            instructorL.Actualizar(i);

            CargarGrid();

            Limpiar();
        }

        protected void gvInstructores_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            GridViewRow fila =
                gvInstructores.SelectedRow;

            hfIdInstructor.Value =
     gvInstructores.DataKeys[
         fila.RowIndex].Values["IdInstructor"]
         .ToString();

            hfIdUsuario.Value =
                gvInstructores.DataKeys[
                    fila.RowIndex].Values["IdUsuario"]
                    .ToString();

            ddlTipoDocumento.SelectedIndex =
                ddlTipoDocumento.Items.IndexOf(
                    ddlTipoDocumento.Items.FindByText(
                        fila.Cells[1].Text));

            txtNumeroDocumento.Text =
                fila.Cells[1].Text;

            txtNombres.Text =
                fila.Cells[2].Text;

            txtApellidos.Text =
                fila.Cells[3].Text;

            txtCorreo.Text =
                fila.Cells[4].Text;

            txtTelefono.Text =
                fila.Cells[5].Text;

            txtEspecialidad.Text =
                fila.Cells[6].Text;
        }

        protected void gvInstructores_RowDeleting(
            object sender,
            GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    gvInstructores.DataKeys[
                        e.RowIndex].Value);

            instructorL.Eliminar(id);

            CargarGrid();
        }

        private void Limpiar()
        {
            hfIdInstructor.Value = "";

            txtNumeroDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtEspecialidad.Text = "";
        }
    }
}