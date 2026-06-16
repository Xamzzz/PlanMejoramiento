<%@ Page Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="GestionAcademica.aspx.cs"
    Inherits="PlanMejoramiento.Vista.GestionAcademica" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="card">

        <h2>Asignación de Instructor Supervisor</h2>

        <hr />

        <div class="form-group">

            <label>Plan de Mejoramiento</label>

            <asp:DropDownList
                ID="ddlPlan"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>

        </div>

        <br />

        <div class="form-group">

            <label>Instructor Supervisor</label>

            <asp:DropDownList
                ID="ddlInstructor"
                runat="server"
                CssClass="form-control">
            </asp:DropDownList>

        </div>

        <br />

        <div class="form-group">

            <label>Fecha Asignación</label>

            <asp:TextBox
                ID="txtFechaAsignacion"
                runat="server"
                TextMode="Date"
                CssClass="form-control">
            </asp:TextBox>

        </div>

        <br />

        <div class="form-group">

            <label>Observación</label>

            <asp:TextBox
                ID="txtObservacion"
                runat="server"
                TextMode="MultiLine"
                Rows="4"
                CssClass="form-control">
            </asp:TextBox>

        </div>

        <br />

        <asp:Button
            ID="btnGuardar"
            runat="server"
            Text="Asignar Supervisor"
            CssClass="btn btn-success"
            OnClick="btnGuardar_Click" />

        <br />
        <br />

        <asp:Label
            ID="lblMensaje"
            runat="server"
            ForeColor="Green">
        </asp:Label>

        <hr />
        <h3>Planes de Mejoramiento</h3>

        <asp:GridView
            ID="gvPlanes"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="table">

            <Columns>

                <asp:BoundField
                    DataField="CodigoFicha"
                    HeaderText="Ficha" />

                <asp:BoundField
                    DataField="Programa"
                    HeaderText="Programa" />

                <asp:BoundField
                    DataField="Jornada"
                    HeaderText="Jornada" />

                <asp:BoundField
                    DataField="Documento"
                    HeaderText="Documento" />

                <asp:BoundField
                    DataField="Aprendiz"
                    HeaderText="Aprendiz" />

                <asp:BoundField
                    DataField="EstadoAprendiz"
                    HeaderText="Estado Aprendiz" />

                <asp:BoundField
                    DataField="TipoPlan"
                    HeaderText="Tipo Plan" />

                <asp:BoundField
                    DataField="EstadoPlan"
                    HeaderText="Estado Plan" />

                <asp:BoundField
                    DataField="FechaAsignacion"
                    HeaderText="Asignación" />

                <asp:BoundField
                    DataField="FechaLimite"
                    HeaderText="Fecha Límite" />

            </Columns>

        </asp:GridView>

        <hr />

        <h3>Historial de Asignaciones</h3>

        <asp:GridView
            ID="gvAsignaciones"
            runat="server"
            CssClass="table"
            AutoGenerateColumns="False">

            <Columns>

                <asp:BoundField
                    DataField="IdAsignacionSupervisor"
                    HeaderText="ID" />

                <asp:BoundField
                    DataField="TipoPlan"
                    HeaderText="Plan" />

                <asp:BoundField
                    DataField="Instructor"
                    HeaderText="Supervisor" />

                <asp:BoundField
                    DataField="FechaAsignacion"
                    HeaderText="Fecha" />

                <asp:BoundField
                    DataField="Observacion"
                    HeaderText="Observación" />

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
