using CRUD_DEFINITIVO.Data.DAO;
using CRUD_DEFINITIVO.Interface;
using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly PersonaDAO _personaDAO;
        public PersonaService(PersonaDAO personaDAO)
        {
            _personaDAO = personaDAO;
        }

        public bool CrearPersona(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                return false;
            }
            return _personaDAO.CrearPersona(persona);
        }
        public List<Persona> ObtenerPersonas()
        {
            return _personaDAO.ObtenerPersonas();
        }
        public bool ActualizarPersona(Persona persona)
        {
            return _personaDAO.ActualizarPersona(persona);
        }
        public bool EliminarPersona(int id)
        {
            return _personaDAO.EliminarPersona(id);
        }
    }
}