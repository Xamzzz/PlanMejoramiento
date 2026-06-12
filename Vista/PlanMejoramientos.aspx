<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="PlanMejoramientos.aspx.cs"
    Inherits="PlanMejoramiento.Vista.PlanMejoramientos" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Plan de Mejoramiento</title>
</head>
<body>

    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>

<a href="Usuarios.aspx">👤 Usuarios</a>



<a href="Login.aspx">🚪 Salir</a>

</div>

        <h2>Plan de Mejoramiento</h2>

        Fecha Asignación

    <br />

        <asp:TextBox
            ID="txtFechaAsignacion"
            runat="server"
            TextMode="Date">
        </asp:TextBox>

        <br />
        <br />

        Actividades

    <br />

        <asp:TextBox
            ID="txtActividades"
            runat="server"
            TextMode="MultiLine"
            Width="400px"
            Height="80px">
        </asp:TextBox>

        <br />
        <br />

        Observaciones

    <br />

        <asp:TextBox
            ID="txtObservaciones"
            runat="server"
            TextMode="MultiLine"
            Width="400px"
            Height="80px">
        </asp:TextBox>

        <br />
        <br />

        Fecha Límite

    <br />

        <asp:TextBox
            ID="txtFechaLimite"
            runat="server"
            TextMode="Date">
        </asp:TextBox>

        <br />
        <br />

        Tipo Plan

    <br />

        <asp:DropDownList
            ID="ddlTipoPlan"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Estado Plan

    <br />

        <asp:DropDownList
            ID="ddlEstadoPlan"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Aprendiz

    <br />

        <asp:DropDownList
            ID="ddlAprendizFicha"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Instructor

    <br />

        <asp:DropDownList
            ID="ddlInstructor"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar"
            OnClick="btnGuardar_Click" />

        <br />
        <br />

        <asp:TemplateField HeaderText="Acciones">

    <ItemTemplate>

        <asp:Button
            ID="btnEditar"
            runat="server"
            Text="Editar"
            CommandName="Editar"
            CommandArgument='<%# Eval("IdPlan") %>' />

        <asp:Button
            ID="btnEliminar"
            runat="server"
            Text="Eliminar"
            CommandName="Eliminar"
            CommandArgument='<%# Eval("IdPlan") %>' />

    </ItemTemplate>

</asp:TemplateField>

        <asp:GridView
            ID="gvPlanes"
            runat="server"
            AutoGenerateColumns="true">
        </asp:GridView>

    </form>

</body>
</html>
