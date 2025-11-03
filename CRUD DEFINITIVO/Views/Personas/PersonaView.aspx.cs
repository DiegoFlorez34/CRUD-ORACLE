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
    public partial class PersonaView : System.Web.UI.Page
    {
        private readonly IPersonaService _personaService;

        public PersonaView()
        {
            _personaService = new PersonaService(new PersonaDAO());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPersonas();
            }
        }
        private void CargarPersonas()
        {
            List<Persona> personas = _personaService.ObtenerPersonas();
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPersona.aspx");
        }
        protected void gvPersonas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            int personaid = Convert.ToInt32(gvPersonas.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditarPersona.aspx?id={personaid}");
        }
        protected void gvPersonas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int personaId = Convert.ToInt32(gvPersonas.DataKeys[e.RowIndex].Value);
            _personaService.EliminarPersona(personaId);

            CargarPersonas();
        }

    }
}