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
    public partial class CrearTipoPersona : System.Web.UI.Page
    {

        private readonly ITipoPersonaService _tipoPersonaService;
        public CrearTipoPersona()
        {
            _tipoPersonaService = new TipoPersonaService(new TipoPersonaDAO());

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoPersona tipoPersona= new TipoPersona
            {
                Descripcion = txtDescripcion.Text,
            };

            bool resultado = _tipoPersonaService.CrearTipoPersona(tipoPersona);

            if (resultado)
                Response.Redirect("TipoPersonaView.aspx");
            else
                Response.Write("<script>alert('Error al guardar el tipo de persona. Verifique los datos.');</script>");
        }
    }
}