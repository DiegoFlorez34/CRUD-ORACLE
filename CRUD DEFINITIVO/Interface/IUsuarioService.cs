using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DEFINITIVO.Interface
{
    public interface IUsuarioService
    {
        bool ValidarUsuario(string usuario, string contraseña);
    }
}
