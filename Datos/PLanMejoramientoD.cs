using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Datos
{
    public class PLanMejoramientoD
    {
        public List<Modelo.PlanMejoramiento> Listar()
        {
            List<Modelo.PlanMejoramiento> lista =
                new List<Modelo.PlanMejoramiento>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                SELECT

                      P.*,

                    TP.NombreTipo,
                    EP.NombreEstado,

                    A.Nombres + ' ' +
                    A.Apellidos
                    AS Aprendiz,

                    I.Nombres + ' ' +
                    I.Apellidos
                    AS Instructor

                FROM PlanMejoramiento P

                INNER JOIN TipoPlan TP
                    ON P.IdTipoPlan =
                       TP.IdTipoPlan

                INNER JOIN EstadoPlan EP
                    ON P.IdEstadoPlan =
                       EP.IdEstadoPlan

                INNER JOIN AprendizFicha AF
                    ON P.IdAprendizFicha = AF.Id

                INNER JOIN Aprendiz A
                    ON AF.IdAprendiz =
                       A.IdAprendiz

                INNER JOIN Instructor I
                    ON P.IdInstructor =
                       I.IdInstructor";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Modelo.PlanMejoramiento p =
                        new Modelo.PlanMejoramiento();

                    p.IdPlan =
                        (int)dr["IdPlan"];

                    p.FechaAsignacion =
                        Convert.ToDateTime(
                            dr["FechaAsignacion"]);

                    p.Actividades =
                        dr["Actividades"].ToString();

                    p.Observaciones =
                        dr["Observaciones"].ToString();

                    p.FechaLimite =
                        Convert.ToDateTime(
                            dr["FechaLimite"]);

                    p.IdTipoPlan =
                        (int)dr["IdTipoPlan"];

                    p.IdEstadoPlan =
                        (int)dr["IdEstadoPlan"];

                    p.IdAprendizFicha =
                        (int)dr["IdAprendizFicha"];

                    p.IdInstructor =
                        (int)dr["IdInstructor"];

                    p.TipoPlan =
                            dr["NombreTipo"].ToString();

                    p.EstadoPlan =
                        dr["NombreEstado"].ToString();

                    p.Aprendiz =
                        dr["Aprendiz"].ToString();

                    p.Instructor =
                        dr["Instructor"].ToString();

                    lista.Add(p);
                }
            }

            return lista;
        }

        public int InsertarRetornandoId(
            Modelo.PlanMejoramiento p)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                INSERT INTO PlanMejoramiento
                (
                    FechaAsignacion,
                    Actividades,
                    Observaciones,
                    FechaLimite,
                    IdTipoPlan,
                    IdEstadoPlan,
                    IdAprendizFicha,
                    IdInstructor
                )

                VALUES
                (
                    @FechaAsignacion,
                    @Actividades,
                    @Observaciones,
                    @FechaLimite,
                    @IdTipoPlan,
                    @IdEstadoPlan,
                    @IdAprendizFicha,
                    @IdInstructor
                );

                SELECT CAST(
                    SCOPE_IDENTITY()
                    AS INT)";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@FechaAsignacion",
                    p.FechaAsignacion);

                cmd.Parameters.AddWithValue(
                    "@Actividades",
                    p.Actividades);

                cmd.Parameters.AddWithValue(
                    "@Observaciones",
                    p.Observaciones);

                cmd.Parameters.AddWithValue(
                    "@FechaLimite",
                    p.FechaLimite);

                cmd.Parameters.AddWithValue(
                    "@IdTipoPlan",
                    p.IdTipoPlan);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoPlan",
                    p.IdEstadoPlan);

                cmd.Parameters.AddWithValue(
                    "@IdAprendizFicha",
                    p.IdAprendizFicha);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    p.IdInstructor);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Actualizar(
            Modelo.PlanMejoramiento p)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                UPDATE PlanMejoramiento

                SET

                    FechaAsignacion =
                        @FechaAsignacion,

                    Actividades =
                        @Actividades,

                    Observaciones =
                        @Observaciones,

                    FechaLimite =
                        @FechaLimite,

                    IdTipoPlan =
                        @IdTipoPlan,

                    IdEstadoPlan =
                        @IdEstadoPlan,

                    IdAprendizFicha =
                        @IdAprendizFicha,

                    IdInstructor =
                        @IdInstructor

                WHERE IdPlan =
                    @IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    p.IdPlan);

                cmd.Parameters.AddWithValue(
                    "@FechaAsignacion",
                    p.FechaAsignacion);

                cmd.Parameters.AddWithValue(
                    "@Actividades",
                    p.Actividades);

                cmd.Parameters.AddWithValue(
                    "@Observaciones",
                    p.Observaciones);

                cmd.Parameters.AddWithValue(
                    "@FechaLimite",
                    p.FechaLimite);

                cmd.Parameters.AddWithValue(
                    "@IdTipoPlan",
                    p.IdTipoPlan);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoPlan",
                    p.IdEstadoPlan);

                cmd.Parameters.AddWithValue(
                    "@IdAprendizFicha",
                    p.IdAprendizFicha);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    p.IdInstructor);

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
                DELETE FROM PlanMejoramiento
                WHERE IdPlan =
                    @IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}