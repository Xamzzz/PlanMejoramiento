using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class InstructorD
    {
        public List<Instructor> Listar()
        {
            List<Instructor> lista =
                new List<Instructor>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                    SELECT
                        I.*,
                        TD.Nombre AS TipoDocumento,
                        I.IdUsuario,
                        U.Usuario

                    FROM Instructor I

                  INNER JOIN TipoDocumento TD
                    ON I.IdTipoDocumento =
                    TD.IdTipoDocumento

                    LEFT JOIN Usuario U
                    ON I.IdUsuario =
                   U.IdUsuario
    
                    WHERE I.Estado = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Instructor i =
                        new Instructor();

                    i.IdInstructor =
                        (int)dr["IdInstructor"];

                    i.IdTipoDocumento =
                        (int)dr["IdTipoDocumento"];

                    i.NumeroDocumento =
                        dr["NumeroDocumento"].ToString();

                    i.Nombres =
                        dr["Nombres"].ToString();

                    i.Apellidos =
                        dr["Apellidos"].ToString();

                    i.Correo =
                        dr["Correo"].ToString();

                    i.Telefono =
                        dr["Telefono"].ToString();

                    i.Especialidad =
                        dr["Especialidad"].ToString();

                    i.Estado =
                        (bool)dr["Estado"];

                    i.TipoDocumento =
                        dr["TipoDocumento"].ToString();

                    i.Usuario =
                        dr["Usuario"].ToString();

                    if (dr["IdUsuario"] != DBNull.Value)
                    {
                        i.IdUsuario =
                            Convert.ToInt32(
                                dr["IdUsuario"]);
                    }

                    lista.Add(i);
                }
            }

            return lista;
        }

        public void Insertar(Instructor i)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO Instructor
        (
            IdTipoDocumento,
            NumeroDocumento,
            Nombres,
            Apellidos,
            Correo,
            Telefono,
            Especialidad,
            Estado,
            IdUsuario
        )
        VALUES
        (
            @IdTipoDocumento,
            @NumeroDocumento,
            @Nombres,
            @Apellidos,
            @Correo,
            @Telefono,
            @Especialidad,
            1,
            @IdUsuario
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    i.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    i.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    i.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    i.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    i.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    i.Telefono);

                cmd.Parameters.AddWithValue(
                    "@Especialidad",
                    i.Especialidad);

                if (i.IdUsuario == 0)
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        i.IdUsuario);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Instructor i)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Instructor
        SET
            IdTipoDocumento = @IdTipoDocumento,
            NumeroDocumento = @NumeroDocumento,
            Nombres = @Nombres,
            Apellidos = @Apellidos,
            Correo = @Correo,
            Telefono = @Telefono,
            Especialidad = @Especialidad,
            IdUsuario = @IdUsuario
        WHERE IdInstructor = @IdInstructor";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    i.IdInstructor);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    i.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    i.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    i.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    i.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    i.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    i.Telefono);

                cmd.Parameters.AddWithValue(
                    "@Especialidad",
                    i.Especialidad);

                if (i.IdUsuario == 0)
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        i.IdUsuario);
                }

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
        UPDATE Instructor
        SET Estado = 0
        WHERE IdInstructor = @IdInstructor";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdInstructor",
                    id);

                cmd.ExecuteNonQuery();
            }
        }

        public int ObtenerIdPorUsuario(
    int idUsuario)
        {
            int idInstructor = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT IdInstructor
        FROM Instructor
        WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);

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
    }
}