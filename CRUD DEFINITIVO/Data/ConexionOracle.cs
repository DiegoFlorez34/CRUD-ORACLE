
using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;

namespace CRUD_DEFINITIVO.Data
{
    public class ConexionOracle
    {
       public static OracleConnection ObtenerConexion()
       {
            string cadena = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;
            OracleConnection conexion = new OracleConnection(cadena);
            return conexion;
       }
        

    }
}