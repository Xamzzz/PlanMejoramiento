using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class EvidenciaD
    {
        public List<Evidencia> Listar()
        {
            List<Evidencia> lista =
                new List<Evidencia>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                SELECT

                    E.*,

                    P.Actividades

                FROM Evidencia E

                INNER JOIN PlanMejoramiento P
                    ON E.IdPlan =
                       P.IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Evidencia e =
                        new Evidencia();

                    e.IdEvidencia =
                        (int)dr["IdEvidencia"];

                    e.NombreArchivo =
                        dr["NombreArchivo"].ToString();

                    e.RutaArchivo =
                        dr["RutaArchivo"].ToString();

                    e.ObservacionInstructor =
                        dr["ObservacionInstructor"].ToString();

                    e.IdPlan =
                        (int)dr["IdPlan"];

                    e.Actividades =
                        dr["Actividades"].ToString();

                    lista.Add(e);
                }

                return lista;
            }
        }

        public void Insertar(Evidencia e)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                INSERT INTO Evidencia
                (
                    NombreArchivo,
                    RutaArchivo,
                    FechaCarga,
                    ObservacionInstructor,
                    IdPlan
                )
                VALUES
                (
                    @NombreArchivo,
                    @RutaArchivo,
                    GETDATE(),
                    @ObservacionInstructor,
                    @IdPlan
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@NombreArchivo",
                    e.NombreArchivo);

                cmd.Parameters.AddWithValue(
                    "@RutaArchivo",
                    e.RutaArchivo);

                cmd.Parameters.AddWithValue(
                    "@ObservacionInstructor",
                    e.ObservacionInstructor);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    e.IdPlan);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                DELETE FROM Evidencia
                WHERE IdEvidencia =
                    @IdEvidencia";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdEvidencia",
                    id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}