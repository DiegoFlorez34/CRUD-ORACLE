<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearPersona.aspx.cs" Inherits="CRUD_DEFINITIVO.Views.Personas.CrearPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Agregar Persona</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h2 class="text-center mb-4">Registrar Nueva Persona</h2>

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
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
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

        <div class="text-end mt-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            <a href="PersonaView.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </form>
</body>
</html>
