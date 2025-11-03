using CRUD_DEFINITIVO.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Data.DAO
{
    public class TipoDocumentoDAO
    {
        public bool CrearTipoDocumento(TipoDocumento tipoDocumento)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {

                string sql = @"INSERT INTO TIPODOCUMENTO (DESCRIPCION)
                VALUES(:descripcion)";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":descripcion", tipoDocumento.Descripcion);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public List<TipoDocumento> ObtenerTipoDocumentos()
        {
            List<TipoDocumento> listaTipoDocumento = new List<TipoDocumento>();
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = "SELECT TIPODOCUMENTOID,DESCRIPCION FROM TIPODOCUMENTO";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaTipoDocumento.Add(new TipoDocumento
                            {
                                TipoDocumentoId = Convert.ToInt32(dr["TIPODOCUMENTOID"]),
                                Descripcion = dr["DESCRIPCION"].ToString()
                            });
                        }
                    }

                }
            }
            return listaTipoDocumento;
        }
        public bool ActualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = @"UPDATE TIPODOCUMENTO 
                        SET DESCRIPCION = :descripcion
                        WHERE TIPODOCUMENTOID= :id"
                        ;
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":descripcion", tipoDocumento.Descripcion);
                    cmd.Parameters.Add(":id", tipoDocumento.TipoDocumentoId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public string EliminarTipoDocumento(int id)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                try
                {
                    string sql = "DELETE FROM TIPODOCUMENTO WHERE TIPODOCUMENTOID = :id";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return "OK";
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 2292)
                    {
                        return "No se puede eliminar existen registros asociados a este tipo de documento";
                    }
                    else
                    {
                        return "Error inesperado: " + ex.Message;
                    }

                }
               
            }
        }

    }
}