<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlanMejoramiento.Vista.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Styles/estilos.css" />
    <title></title>
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI';
            background: #198754;
        }

        .login-container {
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .login-card {
            width: 400px;
            background: white;
            padding: 40px;
            border-radius: 15px;
            box-shadow: 0 10px 25px rgba(0,0,0,.2);
            text-align: center;
        }

        .input {
            width: 100%;
            padding: 12px;
            margin-top: 10px;
            border: 1px solid #ccc;
            border-radius: 8px;
        }

        .btn-login {
            width: 100%;
            padding: 12px;
            margin-top: 20px;
            background: #198754;
            color: white;
            border: none;
            border-radius: 8px;
            cursor: pointer;
        }

            .btn-login:hover {
                background: #157347;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="login-container">

            <div class="login-card">

                <h1>Plan de Mejoramiento SENA</h1>

                <p>Iniciar Sesión</p>

                <asp:TextBox
                    ID="txtUsuario"
                    runat="server"
                    CssClass="input"
                    placeholder="Usuario">
                </asp:TextBox>

                <br />

                <asp:TextBox
                    ID="txtClave"
                    runat="server"
                    CssClass="input"
                    TextMode="Password"
                    placeholder="Contraseña">
                </asp:TextBox>

                <br />

                <asp:Button
                    ID="btnIngresar"
                    runat="server"
                    CssClass="btn-login"
                    Text="Ingresar"
                    OnClick="btnIngresar_Click" />

                <br />
                <br />

                <asp:Label
                    ID="lblMensaje"
                    runat="server"
                    ForeColor="Red">
                </asp:Label>

            </div>

        </div>

    </form>
</body>
</html>
