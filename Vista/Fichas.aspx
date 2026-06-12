<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Fichas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.Fichas" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Gestión de Fichas</title>
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

        <h2>Gestión de Fichas</h2>

        Código Ficha

    <br />

        <asp:TextBox
            ID="txtCodigoFicha"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Fecha Inicio

    <br />

        <asp:TextBox
            ID="txtFechaInicio"
            runat="server"
            TextMode="Date">
        </asp:TextBox>

        <br />
        <br />

        Fecha Finalización

    <br />

        <asp:TextBox
            ID="txtFechaFinalizacion"
            runat="server"
            TextMode="Date">
        </asp:TextBox>

        <br />
        <br />

        Descripción

    <br />

        <asp:TextBox
            ID="txtDescripcion"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Estado

    <br />

        <asp:TextBox
            ID="txtEstado"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Programa

    <br />

        <asp:DropDownList
            ID="ddlPrograma"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Jornada

    <br />

        <asp:DropDownList
            ID="ddlJornada"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        <asp:HiddenField
            ID="hfIdFicha"
            runat="server" />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar"
            OnClick="btnGuardar_Click" />

        <br />
        <br />

        <asp:Button
            ID="btnActualizar"
            runat="server"
            Text="Actualizar"
            OnClick="btnActualizar_Click" />

        <br />
        <br />

        <asp:GridView
            ID="gvFichas"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdFicha"
            OnRowDeleting="gvFichas_RowDeleting"
            OnSelectedIndexChanged="gvFichas_SelectedIndexChanged">

            <Columns>

                <asp:BoundField
                    DataField="CodigoFicha"
                    HeaderText="Código" />

                <asp:BoundField
                    DataField="Programa"
                    HeaderText="Programa" />

                <asp:BoundField
                    DataField="Descripcion"
                    HeaderText="Descripción" />

                <asp:BoundField
                    DataField="Jornada"
                    HeaderText="Jornada" />

                <asp:BoundField
                    DataField="FechaInicio"
                    HeaderText="Inicio" />

                <asp:BoundField
                    DataField="FechaFinalizacion"
                    HeaderText="Finalización" />

                <asp:BoundField
                    DataField="Estado"
                    HeaderText="Estado" />

                <asp:CommandField
                    ShowDeleteButton="True"
                    ShowSelectButton="True" />

            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
