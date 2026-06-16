<%@ Page Language="C#"
MasterPageFile="~/Site1.Master"
AutoEventWireup="true"
CodeBehind="Inicio.aspx.cs"
Inherits="PlanMejoramiento.Vista.Inicio" %>

<asp:Content
ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

<div class="card">

```
<h1>Sistema de Plan de Mejoramiento SENA</h1>

<hr />

<h3>
    Bienvenido:
    <asp:Label
        ID="lblUsuario"
        runat="server">
    </asp:Label>
</h3>

<p>
    Utilice el menú lateral para navegar por las diferentes
    funcionalidades del sistema.
</p>
```

</div>

</asp:Content>
