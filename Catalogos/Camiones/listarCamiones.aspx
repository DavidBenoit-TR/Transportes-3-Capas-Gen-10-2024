<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listarCamiones.aspx.cs" Inherits="Transportes_3_Capas_Gen_10.Catalogos.Camiones.listarCamiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Lista de Camiones</h3>
            <%--Botón de Agregar--%>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVCamiones" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Camion"
                OnRowDeleting="GVCamiones_RowDeleting"
                OnRowCommand="GVCamiones_RowCommand"
                OnRowEditing="GVCamiones_RowEditing"
                OnRowUpdating="GVCamiones_RowUpdating"
                OnRowCancelingEdit="GVCamiones_RowCancelingEdit">

                <Columns>
                    <asp:BoundField DataField="ID_Camion" HeaderText="Número de Camión" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:BoundField DataField="Matricula" HeaderText="Matrícula" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Tipo_camion" HeaderText="Tipo_Camion" ItemStyle-Width="85px" />

                    <asp:TemplateField HeaderText="Disponibilidad" ItemStyle-Width="50px">

                        <ItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto">
                                    <asp:CheckBox ID="chkDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>' Enabled="false" />
                                </div>
                            </div>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto">
                                    <asp:CheckBox ID="chkEditDisponible" runat="server"
                                        Checked='<%#Eval("Disponibilidad")%>' />
                                </div>
                            </div>
                        </EditItemTemplate>

                    </asp:TemplateField>

                    <asp:BoundField DataField="UrlFoto" HeaderText="UrlFoto" ItemStyle-Width="85px" />
                    <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="UrlFoto">
                    </asp:ImageField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
