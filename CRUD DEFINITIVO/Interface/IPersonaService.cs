using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Interface
{
    public interface IPersonaService
    {
        bool CrearPersona(Persona persona);
        List<Persona> ObtenerPersonas();
        bool ActualizarPersona(Persona persona);
        bool EliminarPersona(int id);
    }
}