<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="Evidencias.aspx.cs"
    Inherits="PlanMejoramiento.Vista.Evidencias" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Registro de Evidencias</h2>

    <br />

    <asp:Label
        ID="lblPlan"
        runat="server"
        Text="Plan de Mejoramiento">
    </asp:Label>

    <br />

    <asp:DropDownList
        ID="ddlPlan"
        runat="server"
        Width="400px">
    </asp:DropDownList>

    <br />
    <br />

    <asp:Label
        ID="lblNombreArchivo"
        runat="server"
        Text="Nombre Archivo">
    </asp:Label>

    <br />

    <asp:TextBox
        ID="txtNombreArchivo"
        runat="server"
        Width="400px">
    </asp:TextBox>

    <br />
    <br />

    <asp:Label
        ID="lblArchivo"
        runat="server"
        Text="Seleccionar Archivo">
    </asp:Label>

    <br />

    <asp:FileUpload
        ID="fuArchivo"
        runat="server" />

    <br />
    <br />

    <asp:Label
        ID="lblObservacion"
        runat="server"
        Text="Observación Instructor">
    </asp:Label>

    <br />

    <asp:TextBox
        ID="txtObservacion"
        runat="server"
        TextMode="MultiLine"
        Rows="5"
        Width="500px">
    </asp:TextBox>

    <br />
    <br />

    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar Evidencia"
        OnClick="btnGuardar_Click" />

    <br />
    <br />

    <asp:GridView
        ID="gvEvidencias"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdEvidencia"
        OnRowDeleting="gvEvidencias_RowDeleting">

        <Columns>

            <asp:BoundField
                DataField="IdEvidencia"
                HeaderText="Id" />

            <asp:BoundField
                DataField="NombreArchivo"
                HeaderText="Archivo" />

            <asp:BoundField
                DataField="ObservacionInstructor"
                HeaderText="Observación" />

            <asp:HyperLinkField
                DataNavigateUrlFields="RutaArchivo"
                HeaderText="Ver Evidencia"
                Text="Abrir Archivo"
                Target="_blank" />

            <asp:CommandField
                ShowDeleteButton="True" />

        </Columns>

    </asp:GridView>

</asp:Content>
