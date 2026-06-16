<%@ Page Title="Planes de Mejoramiento"
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="PlanMejoramientos.aspx.cs"
    Inherits="PlanMejoramiento.Vista.PlanMejoramientos" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Plan de Mejoramiento</h2>

    <br />

    Fecha Asignación

    <br />

    <asp:TextBox
        ID="txtFechaAsignacion"
        runat="server"
        TextMode="Date">
    </asp:TextBox>

    <br /><br />

    Actividades

    <br />

    <asp:TextBox
        ID="txtActividades"
        runat="server"
        TextMode="MultiLine"
        Width="400px"
        Height="80px">
    </asp:TextBox>

    <br /><br />

    Observaciones

    <br />

    <asp:TextBox
        ID="txtObservaciones"
        runat="server"
        TextMode="MultiLine"
        Width="400px"
        Height="80px">
    </asp:TextBox>

    <br /><br />

    Fecha Límite

    <br />

    <asp:TextBox
        ID="txtFechaLimite"
        runat="server"
        TextMode="Date">
    </asp:TextBox>

    <br /><br />

    Tipo Plan

    <br />

    <asp:DropDownList
        ID="ddlTipoPlan"
        runat="server">
    </asp:DropDownList>

    <br /><br />

    Estado Plan

    <br />

    <asp:DropDownList
        ID="ddlEstadoPlan"
        runat="server">
    </asp:DropDownList>

    <br /><br />

    Aprendiz

    <br />

    <asp:DropDownList
        ID="ddlAprendizFicha"
        runat="server">
    </asp:DropDownList>

    <br /><br />

    Instructor

    <br />

    <asp:DropDownList
        ID="ddlInstructor"
        runat="server">
    </asp:DropDownList>

    <br /><br />

    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar"
        OnClick="btnGuardar_Click" />

    <br /><br />

    <asp:GridView
        ID="gvPlanes"
        runat="server"
        AutoGenerateColumns="False"
        OnRowCommand="gvPlanes_RowCommand">

        <Columns>

            <asp:BoundField
                DataField="IdPlan"
                HeaderText="ID" />

            <asp:BoundField
                DataField="FechaAsignacion"
                HeaderText="Fecha Asignación" />

            <asp:BoundField
                DataField="Actividades"
                HeaderText="Actividades" />

            <asp:BoundField
                DataField="FechaLimite"
                HeaderText="Fecha Límite" />

            <asp:TemplateField HeaderText="Acciones">

                <ItemTemplate>

                    <asp:Button
                        ID="btnEliminar"
                        runat="server"
                        Text="Eliminar"
                        CommandName="Eliminar"
                        CommandArgument='<%# Eval("IdPlan") %>' />

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>