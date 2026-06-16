<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="CargaMasivaAprendiz.aspx.cs"
    Inherits="PlanMejoramiento.Vista.CargaMasivaAprendiz" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <style>
        .contenedor {
            width: 700px;
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px #ccc;
        }

        .titulo {
            font-size: 28px;
            font-weight: bold;
            color: #198754;
            margin-bottom: 20px;
        }

        .fila {
            margin-bottom: 15px;
        }

        .label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .boton {
            background-color: #198754;
            color: white;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
        }

        .info {
            background-color: #d1ecf1;
            color: #0c5460;
            padding: 10px;
            border-radius: 5px;
            margin-top: 15px;
        }
    </style>

    <div class="contenedor">

        <div class="titulo">
            Carga Masiva de Aprendices
        </div>

        <div class="fila">

            <asp:Label
                ID="lblArchivo"
                runat="server"
                CssClass="label"
                Text="Seleccione el archivo Excel">
            </asp:Label>

            <asp:FileUpload
                ID="fuExcel"
                runat="server" />

        </div>

        <div class="fila">

            <asp:Button
                ID="btnImportar"
                runat="server"
                CssClass="boton"
                Text="Importar Aprendices"
                OnClick="btnImportar_Click" />

        </div>

        <div class="info">

            <strong>Formato esperado del Excel:</strong>

            <br />
            <br />

            IdTipoDocumento |
            NumeroDocumento |
            Nombres |
            Apellidos |
            Correo |
            Telefono |
            IdEstadoAprendiz |
            IdUsuario |
            CodigoFicha

        </div>

        <br />

        <asp:Label
            ID="lblMensaje"
            runat="server"
            Font-Bold="true">
        </asp:Label>

    </div>

</asp:Content>
