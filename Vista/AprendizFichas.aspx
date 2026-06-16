<%@ Page Title="Aprendiz - Ficha"
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="AprendizFichas.aspx.cs"
    Inherits="PlanMejoramiento.Vista.AprendizFichas" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Asignar Aprendiz a Ficha</h2>

    <asp:Label
        ID="Label1"
        runat="server"
        Text="Aprendiz">
    </asp:Label>

    <br />

    <asp:DropDownList
        ID="ddlAprendiz"
        runat="server"
        Width="300px">
    </asp:DropDownList>

    <br />
    <br />

    <asp:Label
        ID="Label2"
        runat="server"
        Text="Ficha">
    </asp:Label>

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