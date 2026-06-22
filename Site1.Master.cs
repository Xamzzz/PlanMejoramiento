using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(
     object sender,
     EventArgs e)
        {
            if (Session["IdRol"] == null)
            {
                Response.Redirect(
                    "~/Vista/Login.aspx");

                return;
            }

            lblUsuario.Text =
                Session["Usuario"].ToString();

            int rol =
                Convert.ToInt32(
                    Session["IdRol"]);

            // ADMINISTRADOR
            if (rol == 1)
            {
                lnkUsuarios.Visible = true;
                lnkAprendices.Visible = true;
                lnkAprendizFicha.Visible = true;
                lnkFichas.Visible = true;
                lnkInstructores.Visible = true;
                lnkInstructorFicha.Visible = true;
                lnkProgramas.Visible = true;
                lnkPlanes.Visible = true;
                lnkEvidencias.Visible = true;
                lnkCargaMasiva.Visible = true;
                lnkEvaluacion.Visible = true;
                lnkGestionAcademica.Visible = true;
                lnkGestionAcademicaCRUD.Visible = true;
            }

            // INSTRUCTOR
            if (rol == 2)
            {
                lnkUsuarios.Visible = false;

                lnkAprendices.Visible = true;

                lnkAprendizFicha.Visible = false;

                lnkFichas.Visible = true;

                lnkInstructores.Visible = false;

                lnkInstructorFicha.Visible = false;

                lnkProgramas.Visible = false;

                lnkPlanes.Visible = true;

                lnkEvidencias.Visible = true;

                lnkCargaMasiva.Visible = false;

                lnkGestionAcademica.Visible = false;

                lnkGestionAcademicaCRUD.Visible = false;

                lnkEvaluacion.Visible = true;
            }

            // APRENDIZ
            if (rol == 3)
            {
                lnkUsuarios.Visible = false;
                lnkAprendices.Visible = false;
                lnkAprendizFicha.Visible = false;
                lnkFichas.Visible = false;
                lnkInstructores.Visible = false;
                lnkInstructorFicha.Visible = false;
                lnkProgramas.Visible = false;
                lnkPlanes.Visible = true;
                lnkEvidencias.Visible = true;
                lnkCargaMasiva.Visible = false;
                lnkEvaluacion.Visible = false;
                lnkGestionAcademica.Visible = false;
                lnkGestionAcademicaCRUD.Visible = false;
            }

            // GESTION ACADEMICA
            if (rol == 4)
            {
                lnkUsuarios.Visible = false;
                lnkAprendices.Visible = false;
                lnkAprendizFicha.Visible = false;
                lnkFichas.Visible = false;
                lnkInstructores.Visible = false;
                lnkInstructorFicha.Visible = false;
                lnkProgramas.Visible = false;
                lnkPlanes.Visible = false;
                lnkEvidencias.Visible = false;
                lnkCargaMasiva.Visible = false;
                lnkGestionAcademica.Visible = true;
                lnkEvaluacion.Visible = false;


                // Solo el administrador crea gestores
                lnkGestionAcademicaCRUD.Visible = false;
            }
        }


        protected void btnSalir_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();

            Session.Abandon();

            Response.Redirect(
                "~/Vista/Login.aspx");
        }
    }
}