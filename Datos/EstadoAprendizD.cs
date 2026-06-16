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

        public int ObtenerIdEnFormacion()
        {
            int id = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                string sql =
                    @"SELECT IdEstadoAprendiz
              FROM EstadoAprendiz
              WHERE NombreEstado =
              'En Formación'";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cn.Open();

                object resultado =
                    cmd.ExecuteScalar();

                if (resultado != null)
                {
                    id = Convert.ToInt32(resultado);
                }
            }

            return id;
        }
    }
}
