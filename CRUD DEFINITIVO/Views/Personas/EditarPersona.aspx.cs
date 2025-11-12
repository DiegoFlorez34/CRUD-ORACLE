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
    public partial class EditarPersona : System.Web.UI.Page
    {

        //LLAMAMOS A LOS DIFERENTES SERVICIOS Q HACEN PARTE DE NUESTRO CONTENIDO DE PERSONAS 
        //INICIALISA OS DAOS 
        private readonly IPersonaService _personaService;
        private readonly ITipoPersonaService _tipoPersonaService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        public EditarPersona()
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
                CargarCombos();// CARGA LOS VALORES DE LOS SELECTS DE TIPO PERSONA Y TIPO DOCUMENTO
                if (Request.QueryString["id"] != null)//COGEMOS LA ID DE OBJETO Q LE DIMOS CLICK A EDITAR
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    CargarPersona(id);//CARGA LOS VALORES QUE TIENE EL OBJETO A EDITAR EN EL FORMULARIO
                }
            }
        }
        // CARGA LOS VALORES DE LOS SELECTS DE TIPO PERSONA Y TIPO DOCUMENTO
        private void CargarCombos()
        {
            //CARGA LOS VALORES A LOS SELECT Y LOS VALORES PREESTABLECIDOS
            ddlTipoPersona.DataSource = _tipoPersonaService.ObtenerTipoPersonas();
            ddlTipoPersona.DataTextField = "Descripcion";
            ddlTipoPersona.DataValueField = "TipoPersonaId";
            ddlTipoPersona.DataBind();

            ddlTipoDocumento.DataSource = _tipoDocumentoService.ObtenerTipoDocumentos();
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "TipoDocumentoId";
            ddlTipoDocumento.DataBind();
        }
        //CARGA LOS VALORES QUE TIENE EL OBJETO A EDITAR EN EL FORMULARIO
        private void CargarPersona(int id)
        {
            var persona = _personaService.ObtenerPersonas().FirstOrDefault(p => p.PersonaId == id);
            if (persona != null)
            {
                hfPersonaId.Value = persona.PersonaId.ToString();
                txtNombre.Text = persona.Nombre;
                txtFechaNacimiento.Text = persona.Fecha_Nacimiento.ToString("yyyy-MM-dd");
                txtCorreo.Text = persona.Correo;
                txtNumeroDocumento.Text = persona.NumeroDocumento;
                ddlTipoPersona.SelectedValue = persona.TipoPersonaId.ToString();
                ddlTipoDocumento.SelectedValue = persona.TipoDocumentoId.ToString();
            }
        }
        //SETEA LOS DATOS EN LA BASE DE DATOS(PSANDO POR CADA UNO DE SUS PASOS)
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //MODIFICA LA PERSONA Y ASIGNA LOS VALORES 
            Persona persona = new Persona
            {
                PersonaId = Convert.ToInt32(hfPersonaId.Value),
                Nombre = txtNombre.Text,
                Fecha_Nacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Correo = txtCorreo.Text,
                NumeroDocumento = txtNumeroDocumento.Text,
                TipoPersonaId = Convert.ToInt32(ddlTipoPersona.SelectedValue),
                TipoDocumentoId = Convert.ToInt32(ddlTipoDocumento.SelectedValue)
            };

            _personaService.ActualizarPersona(persona);
            Response.Redirect("PersonaView.aspx");
        }
    }
}