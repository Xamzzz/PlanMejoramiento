using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class RolD
    {
        public List<Rol> Listar()
        {
            List<Rol> lista =
                new List<Rol>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql =
                    "SELECT * FROM Rol";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Rol r =
                        new Rol();

                    r.IdRol =
                        (int)dr["IdRol"];

                    r.NombreRol =
                        dr["NombreRol"].ToString();

                    lista.Add(r);
                }
            }

            return lista;
        }
    }
}