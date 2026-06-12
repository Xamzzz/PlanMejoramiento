<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programas.aspx.cs" Inherits="PlanMejoramiento.Vista.Programas" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Programas</title>
</head>
<body>
    <form runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>

<a href="Login.aspx">🚪 Salir</a>

</div>

        <h2>Programas</h2>

        Código
    <asp:TextBox ID="txtCodigo"
        runat="server">
    </asp:TextBox>

        <br />
        <br />

        Nombre
    <asp:TextBox ID="txtNombre"
        runat="server">
    </asp:TextBox>

        <br />
        <br />

        Versión
    <asp:TextBox ID="txtVersion"
        runat="server">
    </asp:TextBox>

        <br />
        <br />

        Nivel
    <asp:TextBox ID="txtNivel"
        runat="server">
    </asp:TextBox>

        <br />
        <br />

        Duración
    <asp:TextBox ID="txtDuracion"
        runat="server">
    </asp:TextBox>

        <br />
        <br />

        <asp:HiddenField
            ID="hfIdPrograma"
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

        <asp:GridView
            ID="gvProgramas"
            runat="server"
            AutoGenerateColumns="False"
            OnRowDeleting="gvProgramas_RowDeleting"
            DataKeyNames="IdPrograma"
            OnSelectedIndexChanged="gvProgramas_SelectedIndexChanged">

            <Columns>

                <asp:BoundField
                    DataField="IdPrograma"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="CodigoPrograma"
                    HeaderText="Código" />

                <asp:BoundField
                    DataField="Nombre"
                    HeaderText="Nombre" />

                <asp:BoundField
                    DataField="Version"
                    HeaderText="Versión" />

                <asp:BoundField
                    DataField="Nivel"
                    HeaderText="Nivel" />

                <asp:BoundField
                    DataField="Duracion"
                    HeaderText="Duración" />

                <asp:CommandField
                    ShowDeleteButton="True"
                    ShowSelectButton="True" />

            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
