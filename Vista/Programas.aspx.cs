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
    public partial class Programas : System.Web.UI.Page
    {
        ProgramaL logica = new ProgramaL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }

        }
        private void CargarGrid()
        {
            gvProgramas.DataSource =
                logica.Listar();

            gvProgramas.DataBind();
        }

        protected void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            Programa p = new Programa();

            p.CodigoPrograma =
                txtCodigo.Text;

            p.Nombre =
                txtNombre.Text;

            p.Version =
                txtVersion.Text;

            p.Nivel =
                txtNivel.Text;

            p.Duracion =
                Convert.ToInt32(
                    txtDuracion.Text);

            p.Estado = true;

            logica.Insertar(p);

            CargarGrid();

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtVersion.Text = "";
            txtNivel.Text = "";
            txtDuracion.Text = "";
        }

        protected void gvProgramas_RowDeleting(
            object sender,
            System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id =
                Convert.ToInt32(
                gvProgramas.DataKeys[e.RowIndex].Value);

            logica.Eliminar(id);

            CargarGrid();
        }

        protected void gvProgramas_SelectedIndexChanged(
            object sender,
                EventArgs e)
        {
            GridViewRow fila =
                gvProgramas.SelectedRow;

            hfIdPrograma.Value =
                gvProgramas.DataKeys[
                fila.RowIndex].Value.ToString();

            txtCodigo.Text =
                fila.Cells[1].Text;

            txtNombre.Text =
                fila.Cells[2].Text;

            txtVersion.Text =
                fila.Cells[3].Text;

            txtNivel.Text =
                fila.Cells[4].Text;

            txtDuracion.Text =
                fila.Cells[5].Text;
        }

        protected void btnActualizar_Click(
            object sender,
                EventArgs e)
        {
            Programa p =
                new Programa();

            p.IdPrograma =
                Convert.ToInt32(
                    hfIdPrograma.Value);

            p.CodigoPrograma =
                txtCodigo.Text;

            p.Nombre =
                txtNombre.Text;

            p.Version =
                txtVersion.Text;

            p.Nivel =
                txtNivel.Text;

            p.Duracion =
                Convert.ToInt32(
                    txtDuracion.Text);

            logica.Actualizar(p);

            CargarGrid();
        }


    }
}