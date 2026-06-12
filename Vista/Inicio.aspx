<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PlanMejoramiento.Vista.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>

<a href="Login.aspx">🚪 Salir</a>

</div>
        <div>
            <div class="content">

<div class="card">

<h1 class="titulo">
Sistema de Plan de Mejoramiento
</h1>

<hr />

<h3>
Bienvenido:
<asp:Label
ID="lblUsuario"
runat="server" />
</h3>

<br />

<asp:Button ID="btnUsuarios" runat="server"
Text="👤 Usuarios"  OnClick="btnUsuarios_Click"/>

<asp:Button ID="btnAprendices" runat="server"
Text="🎓 Aprendices" OnClick="btnAprendices_Click" />

<asp:Button ID="btnFichas" runat="server"
Text="📚 Fichas" OnClick="btnFichas_Click" />

<asp:Button ID="btnInstructores" runat="server"
Text="👨‍🏫 Instructores" OnClick="btnInstructores_Click" />

<asp:Button ID="btnProgramas" runat="server"
Text="📖 Programas" OnClick="btnProgramas_Click" />

<asp:Button ID="btnPlanes" runat="server"
Text="📋 Planes" OnClick="btnPlanes_Click"/>

<asp:Button ID="btnEvidencias" runat="server"
Text="📁 Evidencias" OnClick="btnEvidencias_Click" />

<asp:Button ID="btnCargaMasiva" runat="server"
Text="📥 Carga Masiva" OnClick="btnCargaMasiva_Click" />

</div>

</div>
        </div>
    </form>
</body>
</html>
