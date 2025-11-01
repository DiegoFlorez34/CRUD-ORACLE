<%@ Page Title="Gestión de Personas" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="PersonaView.aspx.cs" 
    Inherits="CRUD_DEFINITIVO.Views.Personas.PersonaView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h2 class="text-center mb-4">Gestión de Personas</h2>

        <asp:GridView ID="gvPersonas" 
                      runat="server" 
                      CssClass="table table-bordered table-hover"
                      AutoGenerateColumns="false" 
                      DataKeyNames="PersonaId"
                      OnRowEditing="gvPersonas_RowEditing"
                      OnRowDeleting="gvPersonas_RowDeleting">
            <Columns>
                <asp:BoundField DataField="PersonaId" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Edad" HeaderText="Edad" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" />
                <asp:BoundField DataField="TipoPersonaNombre" HeaderText="Tipo Persona" />
                <asp:BoundField DataField="TipoDocumentoNombre" HeaderText="Tipo Documento" />
                <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" 
                                    Text="Editar" 
                                    CssClass="btn btn-warning btn-sm me-2"
                                    CommandName="Edit" 
                                    CommandArgument='<%# Eval("PersonaId") %>' />
                        <asp:Button runat="server" 
                                    Text="Eliminar" 
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("PersonaId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="text-end mt-3">
            <asp:Button ID="btnAgregar" 
                        runat="server" 
                        Text="Agregar Persona" 
                        CssClass="btn btn-success" 
                        OnClick="btnAgregar_Click" />
        </div>
    </div>

</asp:Content>
