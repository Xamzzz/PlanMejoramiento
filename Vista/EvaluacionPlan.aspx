<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="EvaluacionPlan.aspx.cs"
    Inherits="PlanMejoramiento.Vista.EvaluacionPlan" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Evaluación de Plan de Mejoramiento</h2>

    Plan

    <br />

    <asp:DropDownList
        ID="ddlPlan"
        runat="server">
    </asp:DropDownList>

    <br />
    <br />

    Producto

    <br />

    <asp:DropDownList
        ID="ddlProducto"
        runat="server">
        <asp:ListItem>Aprueba</asp:ListItem>
        <asp:ListItem>No Aprueba</asp:ListItem>
    </asp:DropDownList>

    <br />
    <br />

    Conocimiento

    <br />

    <asp:DropDownList
        ID="ddlConocimiento"
        runat="server">
        <asp:ListItem>Aprueba</asp:ListItem>
        <asp:ListItem>No Aprueba</asp:ListItem>
    </asp:DropDownList>

    <br />
    <br />

    Desempeño

    <br />

    <asp:DropDownList
        ID="ddlDesempeno"
        runat="server">
        <asp:ListItem>Aprueba</asp:ListItem>
        <asp:ListItem>No Aprueba</asp:ListItem>
    </asp:DropDownList>

    <br />
    <br />

    Observaciones

    <br />

    <asp:TextBox
        ID="txtObservaciones"
        runat="server"
        TextMode="MultiLine"
        Rows="4"
        Width="500px">
    </asp:TextBox>

    <br />
    <br />

    <asp:Button
        ID="btnGuardar"
        runat="server"
        Text="Guardar Evaluación"
        OnClick="btnGuardar_Click" />

    <br />
    <br />

    <asp:Label
        ID="lblMensaje"
        runat="server"></asp:Label>

    <br />
    <br />

    <asp:GridView
        ID="gvEvaluaciones"
        runat="server"
        AutoGenerateColumns="true">
    </asp:GridView>

</asp:Content>
