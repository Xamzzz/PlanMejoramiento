using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class TipoDocumentoD
    {
        public List<TipoDocumento> Listar()
        {
            List<TipoDocumento> lista =
                new List<TipoDocumento>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                SELECT *
                FROM TipoDocumento
                WHERE Estado = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    TipoDocumento td =
                        new TipoDocumento();

                    td.IdTipoDocumento =
                        (int)dr["IdTipoDocumento"];

                    td.Sigla =
                        dr["Sigla"].ToString();

                    td.Nombre =
                        dr["Nombre"].ToString();

                    td.Estado =
                        (bool)dr["Estado"];

                    lista.Add(td);
                }
            }

            return lista;
        }
    }
}