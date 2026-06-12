<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlanMejoramiento.Vista.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Styles/estilos.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>



</div>
        <div>
            <asp:Label ID="Label1"
                runat="server"
                Text="Usuario">
            </asp:Label>

            <br />

            <asp:TextBox ID="txtUsuario"
                runat="server">
            </asp:TextBox>

            <br />
            <br />

            <asp:Label ID="Label2"
                runat="server"
                Text="Contraseña">
            </asp:Label>

            <br />

            <asp:TextBox ID="txtClave"
                runat="server"
                TextMode="Password">
            </asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnIngresar"
                runat="server"
                Text="Ingresar"
                OnClick="btnIngresar_Click" />

            <br />
            <br />

            <asp:Label ID="lblMensaje"
                runat="server"
                ForeColor="Red">
            </asp:Label>
        </div>
    </form>
</body>
</html>
