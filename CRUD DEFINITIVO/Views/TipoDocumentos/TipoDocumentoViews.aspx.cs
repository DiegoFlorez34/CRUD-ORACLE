using CRUD_DEFINITIVO.Data.DAO;
using CRUD_DEFINITIVO.Interface;
using CRUD_DEFINITIVO.Models;
using CRUD_DEFINITIVO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_DEFINITIVO.Views.TipoDocumentos
{
    public partial class TipoDocumentoViews : System.Web.UI.Page
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;
        public TipoDocumentoViews()
        {
            _tipoDocumentoService = new TipoDocumentoService(new TipoDocumentoDAO());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                CargarTipoDocumentos();
            }
        }
        private void CargarTipoDocumentos()
        {
            List<TipoDocumento> tipoDocumento = _tipoDocumentoService.ObtenerTipoDocumentos();
            gvTipoDocumentos.DataSource = tipoDocumento;
            gvTipoDocumentos.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearTipoDocumentos.aspx");
        }
        protected void gvTipoDocumentos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int tipoDocumentoId = Convert.ToInt32(gvTipoDocumentos.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditarTipoDocumentos.aspx?id={tipoDocumentoId}");
        }
        protected void gvTipoDocumentos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int tipoDocumentoId = Convert.ToInt32(gvTipoDocumentos.DataKeys[e.RowIndex].Value);

            string  resultado= _tipoDocumentoService.EliminarTipoDocumento(tipoDocumentoId);
            if (resultado=="OK")
            {
                CargarTipoDocumentos();
            }
            else
            {
                Response.Write($"<script>alert('{resultado}');</script>");
            }

        }
    }
}