using CRUD_DEFINITIVO.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_DEFINITIVO.Data.DAO
{
    public class TipoPersonaDAO
    {
        public bool CrearTipoPersona(TipoPersona tipoPersona)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {

                string sql = @"INSERT INTO TIPOPERSONA (DESCRIPCION)
                VALUES(:descripcion)";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":descripcion", tipoPersona.Descripcion);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public List<TipoPersona> ObtenerTipoPersonas()
        {
            List<TipoPersona> listaTipoPersonas = new List<TipoPersona>();
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = "SELECT TIPOPERSONAID,DESCRIPCION FROM TIPOPERSONA";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    conn.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaTipoPersonas.Add(new TipoPersona
                            {
                                TipoPersonaId = Convert.ToInt32(dr["TIPOPERSONAID"]),
                                Descripcion = dr["DESCRIPCION"].ToString()
                            });
                        }
                    }

                }
            }
            return listaTipoPersonas;
        }
        public bool ActualizarTipoPersona(TipoPersona tipoPersona)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = @"UPDATE TIPOPERSONA 
                        SET DESCRIPCION = :descripcion
                        WHERE TIPOPERSONAID= :id";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":descripcion", tipoPersona.Descripcion);
                    cmd.Parameters.Add(":id", tipoPersona.TipoPersonaId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public bool EliminarTipoPersona(int id)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = "DELETE FROM TIPOPERSONA WHERE TIPOPERSONAID = :id";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}