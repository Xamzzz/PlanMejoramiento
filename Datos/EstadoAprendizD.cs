using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class EstadoAprendizD
    {
        public List<EstadoAprendiz> Listar()
        {
            List<EstadoAprendiz> lista =
                new List<EstadoAprendiz>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql =
                    "SELECT * FROM EstadoAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    EstadoAprendiz ea =
                        new EstadoAprendiz();

                    ea.IdEstadoAprendiz =
                        (int)dr["IdEstadoAprendiz"];

                    ea.NombreEstado =
                        dr["NombreEstado"].ToString();

                    lista.Add(ea);
                }
            }

            return lista;
        }
    }
}
