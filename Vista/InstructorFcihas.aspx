<%@ Page Title="Instructor - Ficha"
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="InstructorFcihas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.InstructorFcihas" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Asignar Instructor a Ficha</h2>

    Instructor

    <br />

    <asp:DropDownList
        ID="ddlInstructor"
        runat="server"
        Width="300px">
    </asp:DropDownList>

    <br />
    <br />

    Ficha

    <br />

    <asp:DropDownList
        ID="ddlFicha"
        runat="server"
        Width="300px">
    </asp:DropDownList>

    <br />
    <br />

    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar"
        OnClick="btnGuardar_Click" />

    <br />
    <br />

    <hr />

    <asp:GridView
        ID="gvDatos"
        runat="server"
        AutoGenerateColumns="true">
    </asp:GridView>

</asp:Content>
