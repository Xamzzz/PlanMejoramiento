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
    public partial class Login : System.Web.UI.Page
    {
        public Usuario Usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(
      object sender,
      EventArgs e)
        {
            UsuarioL bl =
                new UsuarioL();

            Usuario usuario =
                bl.Login(
                    txtUsuario.Text,
                    txtClave.Text);

            if (usuario != null)
            {
                Session["IdUsuario"] =
                    usuario.IdUsuario;

                Session["Rol"] =
                    usuario.IdRol;

                Session["Usuario"] =
                    usuario.NombreUsuario;

                Response.Redirect(
                    "Inicio.aspx");
            }
            else
            {
                lblMensaje.Text =
                    "Usuario o contraseña incorrectos";
            }
        }

    }
}