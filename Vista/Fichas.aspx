<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="Fichas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.Fichas" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Gestión de Fichas</h2>

    Código Ficha

    <br />

    <asp:TextBox
        ID="txtCodigoFicha"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Fecha Inicio

    <br />

    <asp:TextBox
        ID="txtFechaInicio"
        runat="server"
        TextMode="Date">
    </asp:TextBox>

    <br />
    <br />

    Fecha Finalización

    <br />

    <asp:TextBox
        ID="txtFechaFinalizacion"
        runat="server"
        TextMode="Date">
    </asp:TextBox>

    <br />
    <br />

    Descripción

    <br />

    <asp:TextBox
        ID="txtDescripcion"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Estado

    <br />

    <asp:TextBox
        ID="txtEstado"
        runat="server">
    </asp:TextBox>

    <br />
    <br />

    Programa

    <br />

    <asp:DropDownList
        ID="ddlPrograma"
        runat="server">
    </asp:DropDownList>

    <br />
    <br />

    Jornada

    <br />

    <asp:DropDownList
        ID="ddlJornada"
        runat="server">
    </asp:DropDownList>

    <br />
    <br />

    <asp:HiddenField
        ID="hfIdFicha"
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

    <br />
    <br />

    <asp:GridView
        ID="gvFichas"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="IdFicha"
        OnRowDeleting="gvFichas_RowDeleting"
        OnSelectedIndexChanged="gvFichas_SelectedIndexChanged">

        <Columns>

            <asp:BoundField
                DataField="CodigoFicha"
                HeaderText="Código" />

            <asp:BoundField
                DataField="Programa"
                HeaderText="Programa" />

            <asp:BoundField
                DataField="Descripcion"
                HeaderText="Descripción" />

            <asp:BoundField
                DataField="Jornada"
                HeaderText="Jornada" />

            <asp:BoundField
                DataField="FechaInicio"
                HeaderText="Inicio" />

            <asp:BoundField
                DataField="FechaFinalizacion"
                HeaderText="Finalización" />

            <asp:BoundField
                DataField="Estado"
                HeaderText="Estado" />

            <asp:CommandField
                ShowDeleteButton="True"
                ShowSelectButton="True" />

        </Columns>

    </asp:GridView>

</asp:Content>
