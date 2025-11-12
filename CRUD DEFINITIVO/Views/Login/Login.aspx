<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD_DEFINITIVO.Views.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5" style="max-width:400px;">
        <h3 class="text-center mb-4">Inicio de Sesión</h3>
        <div class="mb-3">
            <label>Usuario:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label>Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
        <div class="text-center">
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnLogin_Click" />
        </div>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block text-center"></asp:Label>
    </form>
</body>
</html>
