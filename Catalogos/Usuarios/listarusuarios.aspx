<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listarusuarios.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Catalogos.Usuarios.listarusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Lista de Usuarios</h3>
            <asp:Button ID="Insertar" runat="server" Text="Crear" CssClass="btn btn-primary btn-xs" Width="55px" OnClick="Insertar_Click" />
        </div>
        <div class="row">
            <asp:GridView ID="GVUsuarios"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Usuario">

                <Columns>
                    <asp:BoundField DataField="ID_Usuario" HeaderText="# Usuario" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Nombre_Usuario" HeaderText="Nickname" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Rol_ID" HeaderText="Rol" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:ButtonField ButtonType="Button" HeaderText="Editar" CommandName="Select" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
