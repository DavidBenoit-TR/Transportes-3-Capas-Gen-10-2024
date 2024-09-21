<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Catalogos.Usuarios.FormularioUsuario" %>

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
            <asp:Label runat="server">Nombre de Usuario</asp:Label>
            <asp:TextBox ID="txtnickname" runat="server" CssClass="form-control" Placeholder="Ingrese su apodo aquí"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvnickname" runat="server" ControlToValidate="txtnickname" ErrorMessage="El nombre de Usuario es necesario" ValidationGroup="Login"></asp:RequiredFieldValidator>

            <asp:Label ID="lblrol" runat="server" Text="Rol"></asp:Label>
            <asp:DropDownList ID="ddlrol" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblestatus" runat="server" Text="Rol"></asp:Label>
            <asp:CheckBox ID="chkestatus" runat="server" />

            <asp:Label runat="server">Nueva Contraseña</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="La contraseña es necesaria" ValidationGroup="Login"></asp:RequiredFieldValidator>

            <asp:Label runat="server">Confirme Nueva Contraseña</asp:Label>
            <asp:TextBox ID="txtPassword_C" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword_C" runat="server" ControlToValidate="txtPassword" ErrorMessage="La confirmación contraseña es necesaria" ValidationGroup="Login"></asp:RequiredFieldValidator>
            <asp:Label ID="lblPasswordMatch" runat="server" CssClass="text-danger"></asp:Label>

            <br />
            <asp:Button ID="btnGuardar" CssClass="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
