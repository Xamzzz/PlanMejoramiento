<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PlanMejoramiento.Vista.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menu Principal</title>
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
        <div>
            <h1>Menu Principal</h1>

            <asp:HyperLink
                ID="HyperLink1"
                runat="server"
                NavigateUrl="~/Vista/Programas.aspx">
    Administrar Programas
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>
