using PlanMejoramiento.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Datos
{
    public class InstructorFichaD
    {
        public List<InstructorFicha> Listar()
        {
            List<InstructorFicha> lista =
                new List<InstructorFicha>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

                    SELECT

                        IFI.IdInstructorFicha,
                        IFI.IdInstructor,
                        IFI.IdFicha,

                        I.Nombres + ' ' +
                        I.Apellidos
                        AS Instructor,

                        F.CodigoFicha
                        AS Ficha

                    FROM InstructorFicha IFI

                    INNER JOIN Instructor I
                        ON IFI.IdInstructor =
                           I.IdInstructor

                    INNER JOIN Ficha F
                        ON IFI.IdFicha =
                           F.IdFicha";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    InstructorFicha inf =
                        new InstructorFicha();

                    inf.IdInstructorFicha =
                        (int)dr["IdInstructorFicha"];

                    inf.IdInstructor =
                        (int)dr["IdInstructor"];

                    inf.IdFicha =
                        (int)dr["IdFicha"];

                    inf.Instructor =
                        dr["Instructor"].ToString();

                    inf.Ficha =
                        dr["Ficha"].ToString();

                    lista.Add(inf);
                }
            }

            return lista;
        }

        public void Insertar(InstructorFicha inf)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO InstructorFicha
        (
            IdInstructor,
            IdFicha
        )
        VALUES
        (
            @IdInstructor,
            @IdFicha
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    inf.IdInstructor);

                cmd.Parameters.AddWithValue(
                    "@IdFicha",
                    inf.IdFicha);

                cmd.ExecuteNonQuery();
            }
        }
    }
}