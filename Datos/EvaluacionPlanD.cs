using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class EvaluacionPlanD
    {
        public void Insertar(
            EvaluacionPlan e)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                INSERT INTO Evaluacion
                (
                    Producto,
                    Conocimiento,
                    Desempeno,
                    Observaciones,
                    FechaEvaluacion,
                    IdPlan
                )
                VALUES
                (
                    @Producto,
                    @Conocimiento,
                    @Desempeno,
                    @Observaciones,
                    @FechaEvaluacion,
                    @IdPlan
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@Producto",
                    e.Producto);

                cmd.Parameters.AddWithValue(
                    "@Conocimiento",
                    e.Conocimiento);

                cmd.Parameters.AddWithValue(
                    "@Desempeno",
                    e.Desempeno);

                cmd.Parameters.AddWithValue(
                    "@Observaciones",
                    e.Observaciones);

                cmd.Parameters.AddWithValue(
                    "@FechaEvaluacion",
                    e.FechaEvaluacion);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    e.IdPlan);

                cmd.ExecuteNonQuery();
            }
        }

        public List<EvaluacionPlan> Listar()
        {
            List<EvaluacionPlan> lista =
                new List<EvaluacionPlan>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                SELECT

                    E.*,

                    TP.NombreTipo AS TipoPlan,

                    A.Nombres + ' ' +
                    A.Apellidos AS Aprendiz

                FROM Evaluacion E

                INNER JOIN PlanMejoramiento P
                    ON E.IdPlan =
                       P.IdPlan

                INNER JOIN TipoPlan TP
                    ON P.IdTipoPlan =
                       TP.IdTipoPlan

                INNER JOIN AprendizFicha AF
                    ON P.IdAprendizFicha =
                       AF.Id

                INNER JOIN Aprendiz A
                    ON AF.IdAprendiz =
                       A.IdAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    EvaluacionPlan e =
                        new EvaluacionPlan();

                    e.IdEvaluacion =
                        Convert.ToInt32(
                            dr["IdEvaluacion"]);

                    e.Producto =
                        dr["Producto"]
                        .ToString();

                    e.Conocimiento =
                        dr["Conocimiento"]
                        .ToString();

                    e.Desempeno =
                        dr["Desempeno"]
                        .ToString();

                    e.Observaciones =
                        dr["Observaciones"]
                        .ToString();

                    e.FechaEvaluacion =
                        Convert.ToDateTime(
                            dr["FechaEvaluacion"]);

                    e.IdPlan =
                        Convert.ToInt32(
                            dr["IdPlan"]);

                    e.TipoPlan =
                        dr["TipoPlan"]
                        .ToString();

                    e.Aprendiz =
                        dr["Aprendiz"]
                        .ToString();

                    lista.Add(e);
                }
            }

            return lista;
        }
    }
}