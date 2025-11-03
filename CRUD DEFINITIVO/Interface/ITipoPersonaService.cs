using CRUD_DEFINITIVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DEFINITIVO.Interface
{
    public interface ITipoPersonaService
    {

        bool CrearTipoPersona(TipoPersona tipoPersona);

        List<TipoPersona> ObtenerTipoPersonas();

        bool ActualizarTipoPersonas(TipoPersona tipoPersona);

        string EliminarTipoPersonas(int id);

    }
}
