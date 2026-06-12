<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs"
    Inherits="PlanMejoramiento.Vista.Usuarios" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Usuarios</title>
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

        <h2>Gestión de Usuarios</h2>

        Usuario

        <asp:TextBox
            ID="txtUsuario"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Clave

        <asp:TextBox
            ID="txtClave"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Rol

        <asp:DropDownList
            ID="ddlRol"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        <asp:Label ID="LabelDocumento"
            runat="server"
            Text="Número Documento">
        </asp:Label>

        <asp:TextBox ID="txtNumeroDocumento"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:Label ID="LabelNombres"
            runat="server"
            Text="Nombres">
        </asp:Label>

        <asp:TextBox ID="txtNombres"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:Label ID="LabelApellidos"
            runat="server"
            Text="Apellidos">
        </asp:Label>

        <asp:TextBox ID="txtApellidos"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:Label ID="LabelCorreo"
            runat="server"
            Text="Correo">
        </asp:Label>

        <asp:TextBox ID="txtCorreo"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:Label ID="LabelTelefono"
            runat="server"
            Text="Teléfono">
        </asp:Label>

        <asp:TextBox ID="txtTelefono"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:Label ID="LabelEspecialidad"
            runat="server"
            Text="Especialidad">
        </asp:Label>
        <asp:TextBox ID="txtEspecialidad"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        <asp:HiddenField
            ID="hfIdUsuario"
            runat="server" />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Guardar"
            OnClick="btnGuardar_Click" />

        <asp:Button
            ID="btnActualizar"
            runat="server"
            Text="Actualizar"
            OnClick="btnActualizar_Click" />

        <br />
        <br />

        <asp:DropDownList
            ID="ddlTipoDocumento"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        <asp:DropDownList
            ID="ddlEstadoAprendiz"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />
        <asp:GridView
            ID="gvUsuarios"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdUsuario"
            OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"
            OnRowDeleting="gvUsuarios_RowDeleting">

            <Columns>

                <asp:BoundField
                    DataField="IdUsuario"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="NombreUsuario"
                    HeaderText="Usuario" />

                <asp:BoundField
                    DataField="Clave"
                    HeaderText="Clave" />

                <asp:BoundField
                    DataField="Rol"
                    HeaderText="Rol" />

                <asp:CommandField
                    ShowSelectButton="True"
                    ShowDeleteButton="True" />

            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
