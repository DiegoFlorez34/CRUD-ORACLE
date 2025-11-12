using CRUD_DEFINITIVO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_DEFINITIVO.Views.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UsuarioService _usuarioService;
        public Login()
        {
            _usuarioService = new UsuarioService(new Data.DAO.UsuarioDAO());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"]!= null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void btnLogin_Click(object sender,EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPassword.Text;
            bool esValido = _usuarioService.ValidarUsuario(usuario, contraseña);

            if (esValido)
            {
                Session["Usuario"] = usuario;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}