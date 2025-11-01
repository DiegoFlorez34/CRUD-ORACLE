<%@ Page Title="Lista Tipo de Documentos" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="TipoDocumentoViews.aspx.cs" 
    Inherits="CRUD_DEFINITIVO.Views.TipoDocumentos.TipoDocumentoViews" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h2 class="text-center mb-4">Gestión de Tipos de Documento</h2>

        <asp:GridView ID="gvTipoDocumentos" 
                      runat="server" 
                      CssClass="table table-bordered table-hover"
                      AutoGenerateColumns="false" 
                      DataKeyNames="TipoDocumentoId"
                      OnRowEditing="gvTipoDocumentos_RowEditing"
                      OnRowDeleting="gvTipoDocumentos_RowDeleting">
            <Columns>
                <asp:BoundField DataField="TipoDocumentoId" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" 
                                    Text="Editar" 
                                    CssClass="btn btn-warning btn-sm me-2"
                                    CommandName="Edit" 
                                    CommandArgument='<%# Eval("TipoDocumentoId") %>' />
                        <asp:Button runat="server" 
                                    Text="Eliminar" 
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("TipoDocumentoId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="text-end mt-3">
            <asp:Button ID="btnAgregar" 
                        runat="server" 
                        Text="Agregar Tipo de Documento" 
                        CssClass="btn btn-success" 
                        OnClick="btnAgregar_Click" />
        </div>
    </div>

</asp:Content>