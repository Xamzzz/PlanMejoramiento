using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class JornadaD
    {
        public List<Jornada> Listar()
        {
            List<Jornada> lista =
                new List<Jornada>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql =
                    "SELECT * FROM Jornada ORDER BY NombreJornada";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Jornada j =
                        new Jornada();

                    j.IdJornada =
                        (int)dr["IdJornada"];

                    j.NombreJornada =
                        dr["NombreJornada"].ToString();

                    lista.Add(j);
                }
            }

            return lista;
        }
    }
}