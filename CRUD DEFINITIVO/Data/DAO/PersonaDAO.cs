
using CRUD_DEFINITIVO.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace CRUD_DEFINITIVO.Data.DAO
{
    public class PersonaDAO
    {
        public bool CrearPersona(Persona persona)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                
                
                //USO DE UN PL EN CREAR PERSONA
                //using (OracleCommand cmd = new OracleCommand("SP_CREAR_PERSONA", conn))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    cmd.Parameters.Add("P_NOMBRE", OracleDbType.Varchar2).Value = persona.Nombre;
                //    cmd.Parameters.Add("P_EDAD", OracleDbType.Int32).Value = persona.Edad;
                //    cmd.Parameters.Add("P_CORREO", OracleDbType.Varchar2).Value = persona.Correo;
                //    cmd.Parameters.Add("P_TIPOPERSONAID", OracleDbType.Int32).Value = persona.TipoPersonaId;
                //    cmd.Parameters.Add("P_TIPODOCUMENTOID", OracleDbType.Int32).Value = persona.TipoDocumentoId;
                //    cmd.Parameters.Add("P_NUMERODOCUMENTO", OracleDbType.Varchar2).Value = persona.NumeroDocumento;

                //    conn.Open();
                //    return cmd.ExecuteNonQuery() > 0;
                //}


                string sql = @"INSERT INTO PERSONA (NOMBRE,EDAD,CORREO,TIPOPERSONAID,TIPODOCUMENTOID,NUMERODOCUMENTO)
                VALUES(:nombre,:edad,:correo,:tipoPersona,:tipoDocumento,:numeroDocumento)";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":nombre", persona.Nombre);
                    cmd.Parameters.Add(":edad", persona.Edad);
                    cmd.Parameters.Add(":correo", persona.Correo);
                    cmd.Parameters.Add(":tipoPersona", persona.TipoPersonaId);
                    cmd.Parameters.Add(":tipoDocumento", persona.TipoDocumentoId);
                    cmd.Parameters.Add(":numeroDocumento", persona.NumeroDocumento);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public List<Persona> ObtenerPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = @"SELECT P.PERSONAID,
                                      P.NOMBRE,
                                      P.EDAD,
                                      P.CORREO,
                                      P.TIPOPERSONAID,
                                      TP.DESCRIPCION AS TIPO_PERSONA_NOMBRE,
                                      P.TIPODOCUMENTOID,
                                      TD.DESCRIPCION AS TIPO_DOCUMENTO_NOMBRE,
                                      P.NUMERODOCUMENTO
                                FROM PERSONA P
                                JOIN TIPOPERSONA TP ON P.TIPOPERSONAID = TP.TIPOPERSONAID
                                JOIN TIPODOCUMENTO TD ON P.TIPODOCUMENTOID = TD.TIPODOCUMENTOID";
                using (OracleCommand cmd = new OracleCommand(sql,conn))
                {
                    conn.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaPersonas.Add(new Persona
                            {
                                PersonaId = Convert.ToInt32(dr["PERSONAID"]),
                                Nombre = dr["NOMBRE"].ToString(),
                                Edad = Convert.ToInt32(dr["EDAD"]),
                                Correo = dr["CORREO"].ToString(),
                                TipoPersonaId = Convert.ToInt32(dr["TIPOPERSONAID"]),
                                TipoPersonaNombre = dr["TIPO_PERSONA_NOMBRE"].ToString(),
                                TipoDocumentoId = Convert.ToInt32(dr["TIPODOCUMENTOID"]),
                                TipoDocumentoNombre = dr["TIPO_DOCUMENTO_NOMBRE"].ToString(),
                                NumeroDocumento = dr["NUMERODOCUMENTO"].ToString(),
                            });
                        }
                    }
                    
                }   
            }
            return listaPersonas;
        }
        public bool ActualizarPersona(Persona persona)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = @"UPDATE PERSONA 
                        SET NOMBRE = :nombre,
                        EDAD = :edad,
                        CORREO = :correo,
                        TIPOPERSONAID = :tipoPersona,
                        TIPODOCUMENTOID = :tipoDocumento,
                        NUMERODOCUMENTO = :numeroDocumento
                        WHERE PERSONAID= :id"
                        ;
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":nombre", persona.Nombre);
                    cmd.Parameters.Add(":edad", persona.Edad);
                    cmd.Parameters.Add(":correo", persona.Correo);
                    cmd.Parameters.Add(":tipoPersona", persona.TipoPersonaId);
                    cmd.Parameters.Add(":tipoDocumento", persona.TipoDocumentoId);
                    cmd.Parameters.Add(":numeroDocumento", persona.NumeroDocumento);
                    cmd.Parameters.Add(":id", persona.PersonaId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }
        public bool EliminarPersona(int id)
        {
            using (OracleConnection conn = ConexionOracle.ObtenerConexion())
            {
                string sql = "DELETE FROM PERSONA WHERE PERSONAID = :id";
                using (OracleCommand cmd= new OracleCommand(sql,conn))
                {
                    cmd.Parameters.Add(":id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



    }
}