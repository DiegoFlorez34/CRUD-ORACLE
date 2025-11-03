using CRUD_DEFINITIVO.Data.DAO;
using CRUD_DEFINITIVO.Interface;
using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Services
{
    public class TipoDocumentoService: ITipoDocumentoService
    {
        private readonly TipoDocumentoDAO _tipoDocumentoDAO;
        public TipoDocumentoService(TipoDocumentoDAO tipoDocumentoDAO)
        {
            _tipoDocumentoDAO = tipoDocumentoDAO;
        }

        public bool CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            if (string.IsNullOrWhiteSpace(tipoDocumento.Descripcion))
            {
                return false;
            }
            return _tipoDocumentoDAO.CrearTipoDocumento(tipoDocumento);
        }
        public List<TipoDocumento> ObtenerTipoDocumentos()
        {
            return _tipoDocumentoDAO.ObtenerTipoDocumentos();
        }
        public bool ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            return _tipoDocumentoDAO.ActualizarTipoDocumento(tipoDocumento);
        }
        public string EliminarTipoDocumento(int id)
        {
            return _tipoDocumentoDAO.EliminarTipoDocumento(id);
        }


    }
}