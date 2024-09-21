<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioRutas.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Catalogos.Rutas.FormularioRutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>
                <asp:Label ID="titulo" runat="server" Text=""></asp:Label>
            </h3>
            <h4>
                <asp:Label ID="subtitulo" runat="server" Text=""></asp:Label>
            </h4>
        </div>

        <div class="row col-md-5">
            <asp:Label ID="lbldistancia" runat="server" Text="Distancia"></asp:Label>
            <asp:TextBox ID="txtdistancia" runat="server" CssClass="form-control"></asp:TextBox>

            <%--DLL - Drop Down List--%>
            <asp:Label ID="lblcamion" runat="server" Text="Camión"></asp:Label>
            <asp:DropDownList ID="ddlcamion" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblchofer" runat="server" Text="Choferes"></asp:Label>
            <asp:DropDownList ID="ddlchoferes" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblcargamento" runat="server" Text="Cargamentos"></asp:Label>
            <asp:DropDownList ID="ddlcargamentos" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblorigen" runat="server" Text="Dirección de Origen"></asp:Label>
            <asp:DropDownList ID="ddlorigen" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lbldestino" runat="server" Text="Dirección de Destino"></asp:Label>
            <asp:DropDownList ID="ddldestino" runat="server" CssClass="form-control"></asp:DropDownList>

        </div>
        <br />
        <br />
        <%--Renglón para los Calendarios--%>
        <div class="row">
            <div class="col-md-4">
                <h5>
                    <asp:Label ID="lblactual" runat="server" Text="Fecha Actual"></asp:Label>
                </h5>
                <asp:Calendar ID="calactual" runat="server" SelectionMode="None"></asp:Calendar>
            </div>
            <div class="col-md-4">
                <h5>
                    <asp:Label ID="lblsalida" runat="server" Text="Fecha de Salida"></asp:Label>
                </h5>
                <asp:Calendar ID="calsalida" runat="server" OnSelectionChanged="calsalida_SelectionChanged"></asp:Calendar>
            </div>
            <div class="col-md-4">
                <h5>
                    <asp:Label ID="lblestimada" runat="server" Text="Fecha Estimada de Llegada"></asp:Label>
                </h5>
                <asp:Calendar ID="calestimada" runat="server"></asp:Calendar>
            </div>
        </div>
        <br />
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>
</asp:Content>
