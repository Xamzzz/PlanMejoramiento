<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aprendiz.aspx.cs" Inherits="PlanMejoramiento.Vista.Aprendiz" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Aprendices</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>


<a href="Aprendiz.aspx">👨‍🎓 Aprendices</a>

<a href="AprendizFichas.aspx">📚 Aprendiz - Ficha</a>






<a href="Evidencias.aspx">📂 Evidencias</a>



<a href="Login.aspx">🚪 Salir</a>

</div>

        <h2>Gestión de Aprendices</h2>

        Tipo Documento

        <asp:DropDownList
            ID="ddlTipoDocumento"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Número Documento

        <asp:TextBox
            ID="txtNumeroDocumento"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Nombres

        <asp:TextBox
            ID="txtNombres"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Apellidos

        <asp:TextBox
            ID="txtApellidos"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Correo

        <asp:TextBox
            ID="txtCorreo"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Teléfono

        <asp:TextBox
            ID="txtTelefono"
            runat="server">
        </asp:TextBox>

        <br />
        <br />

        Usuario

        <asp:DropDownList
            ID="ddlUsuario"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        Estado Aprendiz

        <asp:DropDownList
            ID="ddlEstadoAprendiz"
            runat="server">
        </asp:DropDownList>

        <br />
        <br />

        <asp:HiddenField
            ID="hfIdAprendiz"
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

        <asp:GridView
            ID="gvAprendiz"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdAprendiz"
           
            OnSelectedIndexChanged="gvAprendiz_SelectedIndexChanged">

            <Columns>

                <asp:BoundField
                    DataField="IdAprendiz"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="TipoDocumento"
                    HeaderText="Tipo Documento" />

                <asp:BoundField
                    DataField="NumeroDocumento"
                    HeaderText="Documento" />

                <asp:BoundField
                    DataField="Nombres"
                    HeaderText="Nombres" />

                <asp:BoundField
                    DataField="Apellidos"
                    HeaderText="Apellidos" />

                <asp:BoundField
                    DataField="Correo"
                    HeaderText="Correo" />

                <asp:BoundField
                    DataField="Telefono"
                    HeaderText="Teléfono" />

                <asp:BoundField
                    DataField="Usuario"
                    HeaderText="Usuario" />

                <asp:BoundField
                    DataField="EstadoAprendiz"
                    HeaderText="Estado" />

                <asp:CommandField
                    ShowSelectButton="True"
                    ShowDeleteButton="True" />

            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
