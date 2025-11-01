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
    public partial class CrearTipoDocumentos : System.Web.UI.Page
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;
        public CrearTipoDocumentos()
        {
            _tipoDocumentoService = new TipoDocumentoService(new TipoDocumentoDAO());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoDocumento tipoDocumento = new TipoDocumento
            {
                Descripcion = txtDescripcion.Text,
            };

            bool resultado = _tipoDocumentoService.CrearTipoDocumento(tipoDocumento);

            if (resultado)
                Response.Redirect("TipoDocumentoViews.aspx");
            else
                Response.Write("<script>alert('Error al guardar el tipo de documento. Verifique los datos.');</script>");
        }
    }
}