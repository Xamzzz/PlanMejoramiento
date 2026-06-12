using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class TipoPlanD
    {
        public List<TipoPlan> Listar()
        {
            List<TipoPlan> lista =
                new List<TipoPlan>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql =
                    "SELECT * FROM TipoPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    TipoPlan tp =
                        new TipoPlan();

                    tp.IdTipoPlan =
                        (int)dr["IdTipoPlan"];

                    tp.NombreTipo =
                        dr["NombreTipo"].ToString();

                    lista.Add(tp);
                }
            }

            return lista;
        }
    }
}