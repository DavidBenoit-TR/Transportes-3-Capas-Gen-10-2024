<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculadora.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Catalogos.Calculadora.Calculadora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center">
            <%--Campos de Texto--%>
            <div class="col-4">
                <asp:Label ID="lbla" runat="server" Text="Número 1"></asp:Label>
                <asp:TextBox ID="txta" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <br />

            <div class="col-4">
                <asp:Label ID="lblb" runat="server" Text="Número 2"></asp:Label>
                <asp:TextBox ID="txtb" runat="server" TextMode="Number"></asp:TextBox>
            </div>

        </div>

        <div class="row text-center">
            <%--Botones--%>
            <asp:Button ID="btnSumar" runat="server" Text="+" OnClick="btnSumar_Click" CssClass="m-5 col" />
            <asp:Button ID="btnRestar" runat="server" Text="-" OnClick="btnRestar_Click" CssClass="m-5 col" />
            <asp:Button ID="btnMultiplicar" runat="server" Text="*" OnClick="btnMultiplicar_Click" CssClass="m-5 col" />
            <asp:Button ID="btnDividir" runat="server" Text="/" OnClick="btnDividir_Click" CssClass="m-5 col" />
        </div>

        <div class="row">
            <div class="text-center">
                <h2>
                    <%--Resultado--%>
                    <asp:Label ID="lblresultado" runat="server" Text=""></asp:Label>
                </h2>
            </div>
        </div>
    </div>
</asp:Content>
