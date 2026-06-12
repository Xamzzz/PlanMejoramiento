using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class ProgramaD
    {
        public List<Programa> Listar()
        {
            List<Programa> lista = new List<Programa>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                        SELECT *
                        FROM Programa
                        WHERE Estado = 1";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Programa p = new Programa();

                    p.IdPrograma = (int)dr["IdPrograma"];
                    p.CodigoPrograma = dr["CodigoPrograma"].ToString();
                    p.Nombre = dr["Nombre"].ToString();
                    p.Version = dr["Version"].ToString();
                    p.Nivel = dr["Nivel"].ToString();
                    p.Duracion = (int)dr["Duracion"];
                    p.Estado = (bool)dr["Estado"];

                    lista.Add(p);
                }
            }

            return lista;
        }

        public void Insertar(Programa p)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"INSERT INTO Programa
                (
                    CodigoPrograma,
                    Nombre,
                    Version,
                    Nivel,
                    Duracion,
                    Estado
                )
                VALUES
                (
                    @CodigoPrograma,
                    @Nombre,
                    @Version,
                    @Nivel,
                    @Duracion,
                    @Estado
                )";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@CodigoPrograma", p.CodigoPrograma);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Version", p.Version);
                cmd.Parameters.AddWithValue("@Nivel", p.Nivel);
                cmd.Parameters.AddWithValue("@Duracion", p.Duracion);
                cmd.Parameters.AddWithValue("@Estado", p.Estado);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Programa
        SET Estado = 0
        WHERE IdPrograma = @IdPrograma";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdPrograma", id);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Programa> ObtenerProgramas()
        {
            return Listar();
        }

        public void Actualizar(Programa p)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Programa
        SET
            CodigoPrograma=@CodigoPrograma,
            Nombre=@Nombre,
            Version=@Version,
            Nivel=@Nivel,
            Duracion=@Duracion
        WHERE IdPrograma=@IdPrograma";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdPrograma", p.IdPrograma);

                cmd.Parameters.AddWithValue(
                    "@CodigoPrograma", p.CodigoPrograma);

                cmd.Parameters.AddWithValue(
                    "@Nombre", p.Nombre);

                cmd.Parameters.AddWithValue(
                    "@Version", p.Version);

                cmd.Parameters.AddWithValue(
                    "@Nivel", p.Nivel);

                cmd.Parameters.AddWithValue(
                    "@Duracion", p.Duracion);

                cmd.ExecuteNonQuery();
            }
        }
    }
}