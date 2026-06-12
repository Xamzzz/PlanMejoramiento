<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="CargaMasivaAprendiz.aspx.cs"
    Inherits="PlanMejoramiento.Vista.CargaMasivaAprendiz" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carga Masiva de Aprendices</title>

    ```
    <style>
        body {
            font-family: Arial;
            background-color: #f4f4f4;
            margin: 30px;
        }

        .contenedor {
            width: 700px;
            margin: auto;
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px #ccc;
        }

        .titulo {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            color: #198754;
            margin-bottom: 20px;
        }

        .fila {
            margin-bottom: 15px;
        }

        .label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .boton {
            background-color: #198754;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
        }

            .boton:hover {
                background-color: #157347;
            }

        .info {
            background-color: #d1ecf1;
            color: #0c5460;
            padding: 10px;
            border-radius: 5px;
            margin-top: 15px;
        }
    </style>
    ```

</head>

<body>

    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>

<a href="Usuarios.aspx">👤 Usuarios</a>

<a href="Aprendiz.aspx">👨‍🎓 Aprendices</a>

<a href="AprendizFichas.aspx">📚 Aprendiz - Ficha</a>

<a href="Fichas.aspx">📋 Fichas</a>

<a href="Instructor.aspx">👨‍🏫 Instructores</a>

<a href="InstructorFcihas.aspx">📝 Instructor - Ficha</a>

<a href="Programas.aspx">🎓 Programas</a>

<a href="PlanMejoramientos.aspx">📈 Planes</a>

<a href="Evidencias.aspx">📂 Evidencias</a>

<a href="CargaMasivaAprendiz.aspx">📤 Carga Masiva</a>

<a href="Login.aspx">🚪 Salir</a>

</div>
        ```
        <div class="contenedor">

            <div class="titulo">
                Carga Masiva de Aprendices
            </div>

            <div class="fila">

                <asp:Label
                    ID="lblArchivo"
                    runat="server"
                    CssClass="label"
                    Text="Seleccione el archivo Excel">
                </asp:Label>

                <asp:FileUpload
                    ID="fuExcel"
                    runat="server" />

            </div>

            <div class="fila">

                <asp:Button
                    ID="btnImportar"
                    runat="server"
                    CssClass="boton"
                    Text="Importar Aprendices"
                    OnClick="btnImportar_Click" />

            </div>

            <div class="info">
                Formato esperado del Excel:

        <br />
                <br />

                IdTipoDocumento |
        NumeroDocumento |
        Nombres |
        Apellidos |
        Correo |
        Telefono |
        IdEstadoAprendiz |
        IdUsuario |
        CodigoFicha

            </div>

            <br />

            <asp:Label
                ID="lblMensaje"
                runat="server"
                Font-Bold="true">
            </asp:Label>

        </div>
        ```

    </form>

</body>
</html>
