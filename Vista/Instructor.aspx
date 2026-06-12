<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="PlanMejoramiento.Vista.Instructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">

<h2>Plan Mejoramiento</h2>

<a href="Inicio.aspx">🏠 Inicio</a>


<a href="Aprendiz.aspx">👨‍🎓 Aprendices</a>

<a href="AprendizFichas.aspx">📚 Aprendiz - Ficha</a>

<a href="Fichas.aspx">📋 Fichas</a>




<a href="PlanMejoramientos.aspx">📈 Planes</a>

<a href="Evidencias.aspx">📂 Evidencias</a>



<a href="Login.aspx">🚪 Salir</a>

</div>
        <div>

            <h2>Gestión de Instructores</h2>

            <asp:HiddenField
                ID="hfIdInstructor"
                runat="server" />

            <asp:HiddenField
                ID="hfIdUsuario"
                runat="server" />

            <table>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblTipoDocumento"
                            runat="server"
                            Text="Tipo Documento:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:DropDownList
                            ID="ddlTipoDocumento"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblNumeroDocumento"
                            runat="server"
                            Text="Número Documento:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtNumeroDocumento"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblNombres"
                            runat="server"
                            Text="Nombres:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtNombres"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblApellidos"
                            runat="server"
                            Text="Apellidos:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtApellidos"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblCorreo"
                            runat="server"
                            Text="Correo:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtCorreo"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblTelefono"
                            runat="server"
                            Text="Teléfono:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtTelefono"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label
                            ID="lblEspecialidad"
                            runat="server"
                            Text="Especialidad:">
                        </asp:Label>
                    </td>

                    <td>
                        <asp:TextBox
                            ID="txtEspecialidad"
                            runat="server">
                        </asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <br />

                        <asp:Button
                            ID="btnActualizar"
                            runat="server"
                            Text="Actualizar"
                            OnClick="btnActualizar_Click" />

                    </td>
                </tr>

            </table>

            <br />
            <hr />
            <br />

            <asp:GridView
                ID="gvInstructores"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="IdInstructor, IdUsuario"
                OnSelectedIndexChanged="gvInstructores_SelectedIndexChanged"
                OnRowDeleting="gvInstructores_RowDeleting">

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
                        DataField="Especialidad"
                        HeaderText="Especialidad" />

                    <asp:BoundField
                        DataField="Usuario"
                        HeaderText="Usuario" />

                    <asp:CommandField
                        ShowSelectButton="True"
                        ShowDeleteButton="True" />

                </Columns>

            </asp:GridView>

        </div>
    </form>
</body>
</html>
