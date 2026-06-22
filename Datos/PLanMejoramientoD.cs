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

        public List<Modelo.ConsultaGestionAcademica>
    ConsultarGestionAcademica()
        {
            List<Modelo.ConsultaGestionAcademica> lista =
                new List<Modelo.ConsultaGestionAcademica>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                SELECT

                    P.IdPlan,

                    F.CodigoFicha,

                    PR.Nombre AS Programa,

                    J.NombreJornada,

                    A.NumeroDocumento,

                    A.Nombres + ' ' +
                    A.Apellidos AS Aprendiz,

                    EA.NombreEstado AS EstadoAprendiz,

                    TP.NombreTipo,

                    EP.NombreEstado AS EstadoPlan,

                    P.FechaAsignacion,

                    P.FechaLimite,

                    P.IdInstructor

                FROM PlanMejoramiento P

                INNER JOIN TipoPlan TP
                ON P.IdTipoPlan = TP.IdTipoPlan

                INNER JOIN EstadoPlan EP
                ON P.IdEstadoPlan = EP.IdEstadoPlan

                INNER JOIN AprendizFicha AF
                ON P.IdAprendizFicha = AF.Id

                INNER JOIN Aprendiz A
                ON AF.IdAprendiz = A.IdAprendiz

                INNER JOIN EstadoAprendiz EA
                ON A.IdEstadoAprendiz =
                   EA.IdEstadoAprendiz

                INNER JOIN Ficha F
                ON AF.IdFicha = F.IdFicha

                INNER JOIN Programa PR
                ON F.IdPrograma = PR.IdPrograma

                INNER JOIN Jornada J
                ON F.IdJornada = J.IdJornada";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    ConsultaGestionAcademica c =
                        new ConsultaGestionAcademica();

                    c.IdPlan =
                        Convert.ToInt32(
                            dr["IdPlan"]);

                    c.CodigoFicha =
                        dr["CodigoFicha"].ToString();

                    c.Programa =
                        dr["Programa"].ToString();

                    c.Jornada =
                        dr["NombreJornada"].ToString();

                    c.Documento =
                        dr["NumeroDocumento"].ToString();

                    c.Aprendiz =
                        dr["Aprendiz"].ToString();

                    c.EstadoAprendiz =
                        dr["EstadoAprendiz"].ToString();

                    c.TipoPlan =
                        dr["NombreTipo"].ToString();

                    c.EstadoPlan =
                        dr["EstadoPlan"].ToString();

                    c.FechaAsignacion =
                        Convert.ToDateTime(
                            dr["FechaAsignacion"]);

                    c.FechaLimite =
                        Convert.ToDateTime(
                            dr["FechaLimite"]);

                    c.IdInstructor =
                        Convert.ToInt32(
                            dr["IdInstructor"]);

                    lista.Add(c);
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

        public int ObtenerInstructorDelPlan(
    int idPlan)
        {
            int idInstructor = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT IdInstructor
        FROM PlanMejoramiento
        WHERE IdPlan = @IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    idPlan);

                object resultado =
                    cmd.ExecuteScalar();

                if (resultado != null)
                {
                    idInstructor =
                        Convert.ToInt32(
                            resultado);
                }
            }

            return idInstructor;
        }

        public void ActualizarEstado(
    int idPlan,
    int idEstado)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE PlanMejoramiento
        SET IdEstadoPlan =
            @IdEstadoPlan
        WHERE IdPlan =
            @IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoPlan",
                    idEstado);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    idPlan);

                cmd.ExecuteNonQuery();
            }
        }

        public Modelo.PlanMejoramiento
    ObtenerPorId(int idPlan)
        {
            Modelo.PlanMejoramiento p =
                null;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT *
        FROM PlanMejoramiento
        WHERE IdPlan = @IdPlan";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    idPlan);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    p =
                        new Modelo.PlanMejoramiento();

                    p.IdPlan =
                        (int)dr["IdPlan"];

                    p.IdAprendizFicha =
                        (int)dr["IdAprendizFicha"];

                    p.IdInstructor =
                        (int)dr["IdInstructor"];
                }
            }

            return p;
        }

        public List<Modelo.PlanMejoramiento>
                    ListarPorAprendiz(
                    int idAprendiz)
        {
            List<Modelo.PlanMejoramiento>
                lista =
                new List<Modelo.PlanMejoramiento>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

        SELECT P.*

        FROM PlanMejoramiento P

        INNER JOIN AprendizFicha AF
            ON P.IdAprendizFicha =
               AF.Id

        WHERE AF.IdAprendiz =
              @IdAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    idAprendiz);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Modelo.PlanMejoramiento p =
                        new Modelo.PlanMejoramiento();

                    p.IdPlan =
                        (int)dr["IdPlan"];

                    lista.Add(p);
                }
            }

            return lista;
        }

        public List<Modelo.PlanMejoramiento>
    ListarPorInstructor(
    int idInstructor)
        {
            List<Modelo.PlanMejoramiento>
                lista =
                new List<Modelo.PlanMejoramiento>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

        SELECT *

        FROM PlanMejoramiento

        WHERE IdInstructor =
              @IdInstructor";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    idInstructor);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Modelo.PlanMejoramiento p =
                        new Modelo.PlanMejoramiento();

                    p.IdPlan =
                        (int)dr["IdPlan"];

                    lista.Add(p);
                }
            }

            return lista;
        }

        public bool ValidarInstructorPlan(
    int idPlan,
    int idInstructor)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

        SELECT COUNT(*)

        FROM PlanMejoramiento

        WHERE IdPlan =
              @IdPlan

        AND IdInstructor =
            @IdInstructor";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPlan",
                    idPlan);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    idInstructor);

                int cantidad =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }
    }
}