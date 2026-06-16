using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class UsuarioD
    {
        public Usuario IniciarSesion(
            string usuario,
            string clave)
        {
            Usuario entidad = null;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();


                string sql = @"
                SELECT *
                FROM Usuario
                WHERE Usuario = @usuario
                AND Clave = @clave
                AND Estado = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@usuario", usuario);

                cmd.Parameters.AddWithValue(
                    "@clave", clave);


                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    entidad = new Usuario();

                    entidad.IdUsuario =
                        (int)dr["IdUsuario"];

                    entidad.NombreUsuario =
                        dr["Usuario"].ToString();

                    entidad.IdRol =
                        (int)dr["IdRol"];

                    entidad.Estado =
                        (bool)dr["Estado"];
                }
            }

            return entidad;

        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista =
                new List<Usuario>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT

            U.IdUsuario,
            U.Usuario,
            U.Clave,
            U.IdRol,
            U.Estado,

            R.NombreRol AS Rol

        FROM Usuario U

        INNER JOIN Rol R
        ON U.IdRol = R.IdRol

        WHERE U.Estado = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario u =
                        new Usuario();

                    u.IdUsuario =
                        (int)dr["IdUsuario"];

                    u.NombreUsuario =
                        dr["Usuario"].ToString();

                    u.Clave =
                        dr["Clave"].ToString();

                    u.IdRol =
                        (int)dr["IdRol"];

                    u.Estado =
                        (bool)dr["Estado"];

                    u.Rol =
                        dr["Rol"].ToString();

                    lista.Add(u);
                }
            }

            return lista;
        }

        public void Insertar(Usuario u)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO Usuario
        (
            Usuario,
            Clave,
            IdRol,
            Estado
        )
        VALUES
        (
            @Usuario,
            @Clave,
            @IdRol,
            1
        )";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    u.NombreUsuario);

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    u.Clave);

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    u.IdRol);

                cmd.ExecuteNonQuery();
            }
        }

        public int InsertarRetornandoId(Usuario u)
        {
            int id = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        INSERT INTO Usuario
        (
            Usuario,
            Clave,
            IdRol,
            Estado
        )
        VALUES
        (
            @Usuario,
            @Clave,
            @IdRol,
            1
        );

        SELECT SCOPE_IDENTITY();";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    u.NombreUsuario);

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    u.Clave);

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    u.IdRol);

                id =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

                return id;
            }
        }

        public void Actualizar(Usuario u)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Usuario
        SET

            Usuario = @Usuario,
            Clave = @Clave,
            IdRol = @IdRol

        WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    u.IdUsuario);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    u.NombreUsuario);

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    u.Clave);

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    u.IdRol);

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
        UPDATE Usuario
        SET Estado = 0
        WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}