using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Data.DAO
{
    public class UsuarioDAO
    {
        public bool ValiarUsuario(string nombreUsuario , string contraseña)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                using (OracleCommand cmd = new OracleCommand("SP_LOGIN_USUARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("P_NOMBRE_USUARIO",OracleDbType.Varchar2).Value = nombreUsuario;
                    cmd.Parameters.Add("P_CONTRASEÑA", OracleDbType.Varchar2).Value=contraseña;

                    OracleParameter resulado = new OracleParameter("P_RESULTADO", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.Parameters.Add(resulado);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    int res = Convert.ToInt32(resulado.Value.ToString());
                    return res == 1;
                }
            }
            
        }
    }
}