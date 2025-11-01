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
    public partial class TipoPersonaView : System.Web.UI.Page
    {
        readonly ITipoPersonaService _tipoPersonaService;
        public TipoPersonaView()
        {
            _tipoPersonaService = new TipoPersonaService(new TipoPersonaDAO());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoPersonas();
            }
        }
        private void CargarTipoPersonas()
        {
            List<TipoPersona> tipoPersona = _tipoPersonaService.ObtenerTipoPersonas();
            gvTipoPersonas.DataSource = tipoPersona;
            gvTipoPersonas.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearTipoPersona.aspx");
        }
        protected void gvTipoPersonas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int tipoPersonaId = Convert.ToInt32(gvTipoPersonas.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditarTipoPersona.aspx?id={tipoPersonaId}");
        }
        protected void gvTipoPersonas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int tipoPersonaId = Convert.ToInt32(gvTipoPersonas.DataKeys[e.RowIndex].Value);
            _tipoPersonaService.EliminarTipoPersonas(tipoPersonaId);
            CargarTipoPersonas();
        }
    }
}