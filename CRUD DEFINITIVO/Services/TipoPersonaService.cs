using CRUD_DEFINITIVO.Data.DAO;
using CRUD_DEFINITIVO.Interface;
using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Services
{
    public class TipoPersonaService : ITipoPersonaService
    {
        private readonly TipoPersonaDAO _tipoPersonaDAO;
        public TipoPersonaService(TipoPersonaDAO tipoPersonaDAO)
        {
            _tipoPersonaDAO = tipoPersonaDAO;
        }

        public bool CrearTipoPersona(TipoPersona tipoPersona)
        {
            if (string.IsNullOrWhiteSpace(tipoPersona.Descripcion))
            {
                return false;
            }
            return _tipoPersonaDAO.CrearTipoPersona(tipoPersona);
        }
        public List<TipoPersona> ObtenerTipoPersonas()
        {
            return _tipoPersonaDAO.ObtenerTipoPersonas();
        }
        public bool ActualizarTipoPersonas(TipoPersona tipoPersona)
        {
            return _tipoPersonaDAO.ActualizarTipoPersona(tipoPersona);
        }
        public string EliminarTipoPersonas(int id)
        {
            return _tipoPersonaDAO.EliminarTipoPersona(id);
        }

    }
}