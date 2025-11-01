<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearTipoDocumentos.aspx.cs" Inherits="CRUD_DEFINITIVO.Views.TipoDocumentos.CrearTipoDocumentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Agregar TipoDocumento</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h2 class="text-center mb-4">Registrar Nuevo Tipo Documento</h2>

        <div class="mb-3">
            <label>Descripcion:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

      
        <div class="text-end mt-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            <a href="TipoDocumentoViews.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </form>
</body>

</html>
