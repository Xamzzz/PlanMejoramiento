using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class EstadoPlanD
    {
        public List<EstadoPlan> Listar()
        {
            List<EstadoPlan> lista =
                new List<EstadoPlan>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql =
                    "SELECT * FROM EstadoPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    EstadoPlan ep =
                        new EstadoPlan();

                    ep.IdEstadoPlan =
                        (int)dr["IdEstadoPlan"];

                    ep.NombreEstado =
                        dr["NombreEstado"].ToString();

                    lista.Add(ep);
                }
            }

            return lista;
        }
    }
}