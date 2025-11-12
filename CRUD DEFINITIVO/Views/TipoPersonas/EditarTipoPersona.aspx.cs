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

namespace CRUD_DEFINITIVO.Views.TipoPersonas
{
    public partial class EditarTipoPersona : System.Web.UI.Page
    {
        private readonly ITipoPersonaService _tipoPersonaService;

        public EditarTipoPersona()
        {
            _tipoPersonaService = new TipoPersonaService(new TipoPersonaDAO());
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
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    CargarTipoPersona(id);
                }

            }
        }
        private void CargarTipoPersona(int id)
        {
            var tipoDocumento = _tipoPersonaService.ObtenerTipoPersonas().FirstOrDefault(p => p.TipoPersonaId == id);
            if (tipoDocumento != null)
            {
                hfTipoPersonaId.Value = tipoDocumento.TipoPersonaId.ToString();
                txtDescripcion.Text = tipoDocumento.Descripcion;
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            TipoPersona tipoPersona = new TipoPersona
            {
                TipoPersonaId = Convert.ToInt32(hfTipoPersonaId.Value),
                Descripcion = txtDescripcion.Text,
            };

            _tipoPersonaService.ActualizarTipoPersonas(tipoPersona);
            Response.Redirect("TipoPersonaView.aspx");
        }
    }
}