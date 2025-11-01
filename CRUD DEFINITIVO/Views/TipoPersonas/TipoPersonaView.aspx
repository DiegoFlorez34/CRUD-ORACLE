<%@ Page Title="Gestión de Tipos de Persona" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="TipoPersonaView.aspx.cs" 
    Inherits="CRUD_DEFINITIVO.Views.TipoPersonas.TipoPersonaView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h2 class="text-center mb-4">Gestión de Tipos de Persona</h2>

        <asp:GridView ID="gvTipoPersonas" 
                      runat="server" 
                      CssClass="table table-bordered table-hover"
                      AutoGenerateColumns="false" 
                      DataKeyNames="TipoPersonaId"
                      OnRowEditing="gvTipoPersonas_RowEditing"
                      OnRowDeleting="gvTipoPersonas_RowDeleting">
            <Columns>
                <asp:BoundField DataField="TipoPersonaId" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" 
                                    Text="Editar" 
                                    CssClass="btn btn-warning btn-sm me-2"
                                    CommandName="Edit" 
                                    CommandArgument='<%# Eval("TipoPersonaId") %>' />
                        <asp:Button runat="server" 
                                    Text="Eliminar" 
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("TipoPersonaId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="text-end mt-3">
            <asp:Button ID="btnAgregar" 
                        runat="server" 
                        Text="Agregar Tipo de Persona" 
                        CssClass="btn btn-success" 
                        OnClick="btnAgregar_Click" />
        </div>
    </div>

</asp:Content>
