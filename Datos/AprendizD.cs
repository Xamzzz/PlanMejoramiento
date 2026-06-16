using PlanMejoramiento.Vista;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Datos
{
    public class AprendizD
    {
        public List<Modelo.Aprendiz> Listar()
        {
            List<Modelo.Aprendiz> lista =
                new List<Modelo.Aprendiz>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                SELECT

                    A.IdAprendiz,
                    A.NumeroDocumento,
                    A.Nombres,
                    A.Apellidos,
                    A.Correo,
                    A.Telefono,
                    A.IdTipoDocumento,
                    A.IdEstadoAprendiz,

                    TD.Nombre AS TipoDocumento,
                    EA.NombreEstado AS EstadoAprendiz,
                    U.Usuario AS Usuario

                FROM Aprendiz A

                INNER JOIN TipoDocumento TD
                    ON A.IdTipoDocumento =
                       TD.IdTipoDocumento

                INNER JOIN EstadoAprendiz EA
                    ON A.IdEstadoAprendiz =
                       EA.IdEstadoAprendiz

                INNER JOIN Usuario U
                ON A.IdUsuario = U.IdUsuario

                WHERE A.Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Modelo.Aprendiz a =
                        new Modelo.Aprendiz();

                    a.IdAprendiz =
                        (int)dr["IdAprendiz"];

                    a.NumeroDocumento =
                        dr["NumeroDocumento"].ToString();

                    a.Nombres =
                        dr["Nombres"].ToString();

                    a.Apellidos =
                        dr["Apellidos"].ToString();

                    a.Correo =
                        dr["Correo"].ToString();

                    a.Telefono =
                        dr["Telefono"].ToString();

                    a.IdTipoDocumento =
                        (int)dr["IdTipoDocumento"];

                    a.IdEstadoAprendiz =
                        (int)dr["IdEstadoAprendiz"];

                    a.TipoDocumento =
                        dr["TipoDocumento"].ToString();

                    a.EstadoAprendiz =
                        dr["EstadoAprendiz"].ToString();

                    a.Usuario =
                        dr["Usuario"].ToString();

                    lista.Add(a);
                }
            }

            return lista;
        }

        public void Insertar(Modelo.Aprendiz a)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO Aprendiz
        (
            IdTipoDocumento,
            NumeroDocumento,
            Nombres,
            Apellidos,
            Correo,
            Telefono,
            IdEstadoAprendiz,
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
            @IdEstadoAprendiz,
            @IdUsuario
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    a.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    a.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    a.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    a.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    a.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    a.Telefono);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoAprendiz",
                    a.IdEstadoAprendiz);

                if (a.IdUsuario == 0)
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        a.IdUsuario);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Modelo.Aprendiz a)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Aprendiz
        SET
            IdTipoDocumento = @IdTipoDocumento,
            NumeroDocumento = @NumeroDocumento,
            Nombres = @Nombres,
            Apellidos = @Apellidos,
            Correo = @Correo,
            Telefono = @Telefono,
            IdEstadoAprendiz = @IdEstadoAprendiz,
            IdUsuario = @IdUsuario
        WHERE IdAprendiz = @IdAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    a.IdAprendiz);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    a.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    a.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    a.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    a.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    a.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    a.Telefono);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoAprendiz",
                    a.IdEstadoAprendiz);

                if (a.IdUsuario == 0)
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        a.IdUsuario);
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
        UPDATE Aprendiz
        SET Activo = 0
        WHERE IdAprendiz = @IdAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    id);

                cmd.ExecuteNonQuery();
            }
        }

        public int InsertarRetornandoId(
    Modelo.Aprendiz a)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

        INSERT INTO Aprendiz
        (
            IdTipoDocumento,
            NumeroDocumento,
            Nombres,
            Apellidos,
            Correo,
            Telefono,
            IdEstadoAprendiz,
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
            @IdEstadoAprendiz,
            @IdUsuario
        );

        SELECT CAST(
            SCOPE_IDENTITY()
            AS INT)";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    a.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    a.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    a.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    a.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    a.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    a.Telefono);

                cmd.Parameters.AddWithValue(
                    "@IdEstadoAprendiz",
                    a.IdEstadoAprendiz);

                if (a.IdUsuario == 0)
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        a.IdUsuario);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        public bool ExisteDocumento(string documento)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"SELECT COUNT(*) 
                       FROM Aprendiz 
                       WHERE NumeroDocumento = @doc";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@doc", documento);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void CambiarEstado(
    int idAprendiz,
    int idEstado)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Aprendiz
        SET IdEstadoAprendiz =
            @IdEstado
        WHERE IdAprendiz =
            @IdAprendiz";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdEstado",
                    idEstado);

                cmd.Parameters.AddWithValue(
                    "@IdAprendiz",
                    idAprendiz);

                cmd.ExecuteNonQuery();
            }
        }

    }
}