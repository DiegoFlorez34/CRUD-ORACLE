<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarTipoPersona.aspx.cs" Inherits="CRUD_DEFINITIVO.Views.TipoPersonas.EditarTipoPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Editar Tipo Persona</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h2 class="text-center mb-4">Editar Tipo Persona</h2>

        <asp:HiddenField ID="hfTipoPersonaId" runat="server" />

        <div class="mb-3">
            <label>Descripcion:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="text-end">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
            <a href="TipoPersonaView.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </form>
</body>
</html>
