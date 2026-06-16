using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class AsignacionSupervisorD
    {
        public void Insertar(
            AsignacionSupervisor a)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                INSERT INTO AsignacionSupervisor
                (
                    IdPlan,
                    IdInstructorSupervisor,
                    Observacion,
                    FechaAsignacion,
                    IdGestionAcademica
                )
                VALUES
                (
                    @IdPlan,
                    @IdInstructorSupervisor,
                    @Observacion,
                    @FechaAsignacion,
                    @IdGestionAcademica
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    a.IdPlan);

                cmd.Parameters.AddWithValue(
                    "@IdInstructorSupervisor",
                    a.IdInstructorSupervisor);

                cmd.Parameters.AddWithValue(
                    "@Observacion",
                    a.Observacion);

                cmd.Parameters.AddWithValue(
                    "@FechaAsignacion",
                    a.FechaAsignacion);

                cmd.Parameters.AddWithValue(
                    "@IdGestionAcademica",
                    a.IdGestionAcademica);

                cmd.ExecuteNonQuery();
            }
        }

        public List<AsignacionSupervisor> Listar()
        {
            List<AsignacionSupervisor> lista =
                new List<AsignacionSupervisor>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                    SELECT

                        A.IdAsignacionSupervisor,
                        A.IdPlan,
                        A.IdInstructorSupervisor,
                        A.Observacion,
                        A.FechaAsignacion,

                        TP.NombreTipo AS TipoPlan,

                        I.Nombres + ' ' +
                        I.Apellidos AS Instructor

                    FROM AsignacionSupervisor A

                    INNER JOIN PlanMejoramiento P
                    ON A.IdPlan = P.IdPlan

                    INNER JOIN TipoPlan TP
                    ON P.IdTipoPlan =
                       TP.IdTipoPlan

                    INNER JOIN Instructor I
                    ON A.IdInstructorSupervisor =
                       I.IdInstructor

                    WHERE A.Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    AsignacionSupervisor a =
                        new AsignacionSupervisor();

                    a.IdAsignacionSupervisor =
                        Convert.ToInt32(
                            dr["IdAsignacionSupervisor"]);

                    a.IdPlan =
                        Convert.ToInt32(
                            dr["IdPlan"]);

                    a.IdInstructorSupervisor =
                        Convert.ToInt32(
                            dr["IdInstructorSupervisor"]);

                    a.Observacion =
                        dr["Observacion"]
                        .ToString();

                    a.FechaAsignacion =
                        Convert.ToDateTime(
                            dr["FechaAsignacion"]);

                    a.TipoPlan =
                        dr["TipoPlan"]
                        .ToString();

                    a.Instructor =
                        dr["Instructor"]
                        .ToString();

                    lista.Add(a);
                }
            }

            return lista;
        }
    }
}