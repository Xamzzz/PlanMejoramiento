using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class Inicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int rol =
                    Convert.ToInt32(Session["Rol"]);

                lblUsuario.Text =
                    "Bienvenido: " +
                    Session["Usuario"];

                if (rol == 2) // Instructor
                {
                    btnUsuarios.Visible = false;
                    btnProgramas.Visible = false;
                }

                if (rol == 3) // Aprendiz
                {
                    btnUsuarios.Visible = false;
                    btnProgramas.Visible = false;
                    btnInstructores.Visible = false;
                    btnFichas.Visible = false;
                }
            }
        }



        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Session.Abandon();

            Response.Redirect(
                "Login.aspx");
        }

        protected void btnUsuarios_Click(
     object sender,
     EventArgs e)
        {
            Response.Redirect(
                "Usuarios.aspx");
        }

        protected void btnAprendices_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect(
                "Aprendiz.aspx");
        }

        protected void btnFichas_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect(
                "Fichas.aspx");
        }

        protected void btnInstructores_Click(object sender, EventArgs e)
        {
            Response.Redirect(
                "Instructor.aspx");
        }

        protected void btnProgramas_Click(object sender, EventArgs e)
        {
            Response.Redirect(
                "Programas.aspx");
        }

        protected void btnPlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanMejoramientos.aspx");
        }

        protected void btnEvidencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("Evidencias.aspx");
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargaMasivaAprendiz.aspx");
        }
    }
}