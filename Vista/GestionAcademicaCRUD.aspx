<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="GestionAcademicaCRUD.aspx.cs"
    Inherits="PlanMejoramiento.Vista.GestionAcademicaCRUD" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Gestión Académica</h2>

    <asp:HiddenField
        ID="hfIdGestionAcademica"
        runat="server" />

    Tipo Documento

    <br />

    <asp:DropDownList
        ID="ddlTipoDocumento"
        runat="server">
    </asp:DropDownList>

    <br />
    <br />

    Número Documento

    <br />

    <asp:TextBox
        ID="txtNumeroDocumento"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Nombres

    <br />

    <asp:TextBox
        ID="txtNombres"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Apellidos

    <br />

    <asp:TextBox
        ID="txtApellidos"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Correo

    <br />

    <asp:TextBox
        ID="txtCorreo"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Teléfono

    <br />

    <asp:TextBox
        ID="txtTelefono"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar"
        OnClick="btnGuardar_Click" />

    <br />
    <br />

    <asp:GridView
        ID="gvGestionAcademica"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdGestionAcademica"
        OnRowDeleting="gvGestionAcademica_RowDeleting">

        <Columns>

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

            <asp:CommandField
                ShowDeleteButton="True" />

        </Columns>

    </asp:GridView>

</asp:Content>
