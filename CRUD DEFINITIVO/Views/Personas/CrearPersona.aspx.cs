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

namespace CRUD_DEFINITIVO.Views.Personas
{
    public partial class CrearPersona : System.Web.UI.Page
    {
        private readonly IPersonaService _personaService;
        private readonly ITipoPersonaService _tipoPersonaService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        public CrearPersona()
        {
            _personaService = new PersonaService(new PersonaDAO());
            _tipoDocumentoService = new TipoDocumentoService(new TipoDocumentoDAO());
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
                CargarCombos();
            }
        }
        private void CargarCombos()
        {
            ddlTipoPersona.DataSource = _tipoPersonaService.ObtenerTipoPersonas();
            ddlTipoPersona.DataTextField = "Descripcion";
            ddlTipoPersona.DataValueField = "TipoPersonaId";
            ddlTipoPersona.DataBind();

            ddlTipoDocumento.DataSource = _tipoDocumentoService.ObtenerTipoDocumentos();
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "TipoDocumentoId";
            ddlTipoDocumento.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona
            {
                Nombre = txtNombre.Text,
                Fecha_Nacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Correo = txtCorreo.Text,
                NumeroDocumento = txtNumeroDocumento.Text,
                TipoPersonaId = Convert.ToInt32(ddlTipoPersona.SelectedValue),
                TipoDocumentoId = Convert.ToInt32(ddlTipoDocumento.SelectedValue)
            };

            bool resultado = _personaService.CrearPersona(persona);

           if (resultado)
                Response.Redirect("PersonaView.aspx");
           else
            Response.Write("<script>alert('OK.');</script>");
            Response.Redirect("PersonaView.aspx");
        }
    }
}