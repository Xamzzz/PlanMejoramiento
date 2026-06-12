<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AprendizFichas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.AprendizFichas" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Aprendiz Ficha</title>
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

        <h2>Asignar Aprendiz a Ficha</h2>

        <asp:Label ID="Label1"
            runat="server"
            Text="Aprendiz">
        </asp:Label>

        <br />

        <asp:DropDownList
            ID="ddlAprendiz"
            runat="server"
            Width="300px">
        </asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label2"
            runat="server"
            Text="Ficha">
        </asp:Label>

        <br />

        <asp:DropDownList
            ID="ddlFicha"
            runat="server"
            Width="300px">
        </asp:DropDownList>

        <br /><br />

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