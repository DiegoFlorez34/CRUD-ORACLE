using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_DEFINITIVO
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Views/Login/Login.aspx");
                return;
            }
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Elimina la sesión actual
            Session.Clear();
            Session.Abandon();

            //Elimina cookies 
            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                var cookie = new HttpCookie(".ASPXAUTH");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            // Redirige al login
            Response.Redirect("~/Views/Login/Login.aspx");
        }
    }
}