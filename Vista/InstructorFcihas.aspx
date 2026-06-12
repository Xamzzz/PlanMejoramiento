<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="InstructorFcihas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.InstructorFcihas" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Instructor Ficha</title>
</head>
<body>

    <form id="form1" runat="server">

        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>



<a href="Login.aspx">🚪 Salir</a>

</div>
        <h2>Asignar Instructor a Ficha</h2>

        Instructor

    <br />

        <asp:DropDownList
            ID="ddlInstructor"
            runat="server"
            Width="300px">
        </asp:DropDownList>

        <br />
        <br />

        Ficha

    <br />

        <asp:DropDownList
            ID="ddlFicha"
            runat="server"
            Width="300px">
        </asp:DropDownList>

        <br />
        <br />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar"
            OnClick="btnGuardar_Click" />

        <hr />

        <asp:GridView
            ID="gvDatos"
            runat="server"
            AutoGenerateColumns="true">
        </asp:GridView>

    </form>

</body>
</html>
