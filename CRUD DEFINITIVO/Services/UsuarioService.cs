using CRUD_DEFINITIVO.Data.DAO;
using CRUD_DEFINITIVO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioDAO _usuarioDAO;
        public UsuarioService(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        public bool ValidarUsuario(string usuario,string contraseña)
        {
            try
            {
                return _usuarioDAO.ValiarUsuario(usuario, contraseña);
            }
            catch
            {

                return false;
            }
        }
    }
}