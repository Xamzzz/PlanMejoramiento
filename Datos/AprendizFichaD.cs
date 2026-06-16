using PlanMejoramiento.Modelo;
using PlanMejoramiento.Vista;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class AprendizFichaD
    {
        public List<AprendizFicha> Listar()
        {
            List<AprendizFicha> lista =
                new List<AprendizFicha>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                    SELECT

                        AF.Id,
                        AF.IdAprendiz,
                        AF.IdFicha,

                        A.Nombres + ' ' +
                        A.Apellidos AS Aprendiz,

                        F.CodigoFicha AS Ficha

                    FROM AprendizFicha AF

                    INNER JOIN Aprendiz A
                        ON AF.IdAprendiz = A.IdAprendiz

                    INNER JOIN Ficha F
                        ON AF.IdFicha = F.IdFicha

                    WHERE AF.Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    AprendizFicha af =
                        new AprendizFicha();

                    af.IdAprendizFicha =
                        (int)dr["Id"];

                    af.IdAprendiz =
                        (int)dr["IdAprendiz"];

                    af.IdFicha =
                        (int)dr["IdFicha"];

                    af.Aprendiz =
                        dr["Aprendiz"].ToString();

                    af.Ficha =
                        dr["Ficha"].ToString();

                    lista.Add(af);
                }
            }

            return lista;
        }

        public void Insertar(AprendizFicha af)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                
        string sql = @"
                INSERT INTO AprendizFicha
                (
                    IdAprendiz,
                    IdFicha,
                    FechaIngreso,
                    Estado,
                    Activo
                )
                VALUES
                (
                    @IdAprendiz,
                    @IdFicha,
                    GETDATE(),
                    1,
                    1
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    af.IdAprendiz);

                cmd.Parameters.AddWithValue(
                    "@IdFicha",
                    af.IdFicha);

                cmd.ExecuteNonQuery();
            }
        }

        public int Guardar(AprendizFicha af)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO AprendizFicha
        (
            IdAprendiz,
            IdFicha,
            FechaIngreso,
            Estado,
            Activo
        )
        VALUES
        (
            @IdAprendiz,
            @IdFicha,
            GETDATE(),
            1,
            1
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    af.IdAprendiz);

                cmd.Parameters.AddWithValue(
                    "@IdFicha",
                    af.IdFicha);

                return cmd.ExecuteNonQuery();
            }
        }
        public void InsertarMasivo(
     int idAprendiz,
     int idFicha)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

        INSERT INTO AprendizFicha
        (
            IdAprendiz,
            IdFicha,
            FechaIngreso,
            Activo
        )
        VALUES
        (
            @IdAprendiz,
            @IdFicha,
            GETDATE(),
            1
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    idAprendiz);

                cmd.Parameters.AddWithValue(
                    "@IdFicha",
                    idFicha);

                cmd.ExecuteNonQuery();
            }
        }

        public int ObtenerAprendizPorFicha(
    int idAprendizFicha)
        {
            int idAprendiz = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT IdAprendiz
        FROM AprendizFicha
        WHERE Id = @Id";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@Id",
                    idAprendizFicha);

                object resultado =
                    cmd.ExecuteScalar();

                if (resultado != null)
                {
                    idAprendiz =
                        Convert.ToInt32(
                            resultado);
                }
            }

            return idAprendiz;
        }
    }
}