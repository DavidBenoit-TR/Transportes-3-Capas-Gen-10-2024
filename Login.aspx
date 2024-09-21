<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <%--Nickname--%>
        <div class="form-outline mb-4">
            <asp:Label runat="server">Nombre de Usuario</asp:Label>
            <asp:TextBox ID="txtnickname" runat="server" CssClass="form-control" Placeholder="Ingrese su apodo aquí"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvnickname" runat="server" ControlToValidate="txtnickname" ErrorMessage="El nombre de Usuario es necesario" ValidationGroup="Login"></asp:RequiredFieldValidator>
        </div>
        <%--Password--%>
        <div class="form-outline mb-4">
            <asp:Label runat="server">Contraseña</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="La contraseña es necesaria" ValidationGroup="Login"></asp:RequiredFieldValidator>
        </div>
        <%--Botón de Enviar--%>
        <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary btn-block mb-4" ValidationGroup="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
