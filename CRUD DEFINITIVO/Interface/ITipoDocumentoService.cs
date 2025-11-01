using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DEFINITIVO.Interface
{
    public interface ITipoDocumentoService
    {


         bool CrearTipoDocumento(TipoDocumento tipoDocumento);
         List<TipoDocumento> ObtenerTipoDocumentos();
        bool ActualizarTipoDocumento(TipoDocumento tipoDocumento);

         bool EliminarTipoDocumento(int id);


    }
}
