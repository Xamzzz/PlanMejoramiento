<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Evidencias.aspx.cs"
    Inherits="PlanMejoramiento.Vista.Evidencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evidencias</title>

    <style>
        body {
            font-family: Arial;
            margin: 30px;
        }

        .contenedor {
            width: 700px;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
        }

        .titulo {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .fila {
            margin-bottom: 15px;
        }

        .etiqueta {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .caja {
            width: 100%;
            padding: 8px;
        }

        .boton {
            padding: 10px 20px;
        }
    </style>

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

        <div class="contenedor">

            <div class="titulo">
                Registro de Evidencias
            </div>

            <div class="fila">

                <asp:Label
                    ID="lblPlan"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Plan de Mejoramiento">
                </asp:Label>

                <asp:DropDownList
                    ID="ddlPlan"
                    runat="server"
                    CssClass="caja">
                </asp:DropDownList>

            </div>

            <div class="fila">

                <asp:Label
                    ID="lblNombreArchivo"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Nombre Archivo">
                </asp:Label>

                <asp:TextBox
                    ID="txtNombreArchivo"
                    runat="server"
                    CssClass="caja">
                </asp:TextBox>

            </div>

            <div class="fila">

                <asp:Label
                    ID="lblArchivo"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Seleccionar Archivo">
                </asp:Label>

                <asp:FileUpload
                    ID="fuArchivo"
                    runat="server" />

            </div>

            <div class="fila">

                <asp:Label
                    ID="lblObservacion"
                    runat="server"
                    CssClass="etiqueta"
                    Text="Observación Instructor">
                </asp:Label>

                <asp:TextBox
                    ID="txtObservacion"
                    runat="server"
                    TextMode="MultiLine"
                    Rows="5"
                    CssClass="caja">
                </asp:TextBox>

            </div>

            <div class="fila">

                <asp:Button
                    ID="btnGuardar"
                    runat="server"
                    CssClass="boton"
                    Text="Guardar Evidencia"
                    OnClick="btnGuardar_Click" />

            </div>

        </div>

        <br />

        <asp:GridView
            ID="gvEvidencias"
            runat="server"
            AutoGenerateColumns="False">

            <Columns>

                <asp:BoundField
                    DataField="IdEvidencia"
                    HeaderText="Id" />

                <asp:BoundField
                    DataField="NombreArchivo"
                    HeaderText="Archivo" />

                <asp:BoundField
                    DataField="ObservacionInstructor"
                    HeaderText="Observación" />

                <asp:HyperLinkField
                    DataNavigateUrlFields="RutaArchivo"
                    HeaderText="Ver Evidencia"
                    Text="Abrir Archivo"
                    Target="_blank" />

                <asp:ButtonField
                    Text="Eliminar"
                    CommandName="Eliminar" />

            </Columns>

        </asp:GridView>

    </form>

</body>
</html>
