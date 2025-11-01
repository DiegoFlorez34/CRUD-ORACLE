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
    public partial class EditarTipoDocumentos : System.Web.UI.Page
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public EditarTipoDocumentos()
        {
            _tipoDocumentoService = new TipoDocumentoService(new TipoDocumentoDAO());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    CargarTipoDocumento(id);
                }

            }

        }
        private void CargarTipoDocumento(int id)
        {
            var tipoDocumento = _tipoDocumentoService.ObtenerTipoDocumentos().FirstOrDefault(p => p.TipoDocumentoId == id);
            if (tipoDocumento != null)
            {
                hfTipoDocumentoId.Value = tipoDocumento.TipoDocumentoId.ToString();
                txtDescripcion.Text = tipoDocumento.Descripcion;
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            TipoDocumento tipoDocumento = new TipoDocumento
            {
                TipoDocumentoId = Convert.ToInt32(hfTipoDocumentoId.Value),
                Descripcion = txtDescripcion.Text,
            };

            _tipoDocumentoService.ActualizarTipoDocumento(tipoDocumento);
            Response.Redirect("TipoDocumentoViews.aspx");
        }
    }
}