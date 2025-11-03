<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPersona.aspx.cs" Inherits="CRUD_DEFINITIVO.Views.Personas.EditarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<title>Editar Persona</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>



<body>
    <form id="form1" runat="server" class="container mt-4">
        <h2 class="text-center mb-4">Editar Persona</h2>

        <asp:HiddenField ID="hfPersonaId" runat="server" />

        <div class="mb-3">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Fecha Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Tipo Persona:</label>
            <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="mb-3">
            <label>Tipo Documento:</label>
            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>

        <div class="mb-3">
            <label>Número Documento:</label>
            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="text-end">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
            <a href="PersonaView.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </form>
</body>
</html>
