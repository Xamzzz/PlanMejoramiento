using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Datos
{
    public class FichaD
    {


        public List<Fichas> Listar()
        {
            List<Fichas> lista = new List<Fichas>();

            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"SELECT
                                 F.IdFicha,
                                 F.CodigoFicha,
                                 F.FechaInicio,
                                F.FechaFinalizacion,
                                F.Descripcion,
                                F.Estado,
                        F.IdPrograma,
                        F.IdJornada,

                        P.Nombre AS Programa,
                        J.NombreJornada AS Jornada

                    FROM Ficha F

                    INNER JOIN Programa P
                    ON F.IdPrograma = P.IdPrograma

                    INNER JOIN Jornada J
                        ON F.IdJornada = J.IdJornada
                            WHERE F.Activo = 1";

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Fichas f = new Fichas();

                    f.IdFicha = (int)dr["IdFicha"];
                    f.CodigoFicha = dr["CodigoFicha"].ToString();
                    f.FechaInicio = (System.DateTime)dr["FechaInicio"];
                    f.FechaFinalizacion = (System.DateTime)dr["FechaFinalizacion"];
                    f.Descripcion = dr["Descripcion"].ToString();
                    f.Estado = dr["Estado"].ToString();
                    f.IdPrograma = (int)dr["IdPrograma"];
                    f.IdJornada = (int)dr["IdJornada"];
                    f.Programa = dr["Programa"].ToString();
                    f.Jornada = dr["Jornada"].ToString();

                    lista.Add(f);
                }
            }

            return lista;
        }

        public void Insertar(Fichas f)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                INSERT INTO Ficha
                (
                    CodigoFicha,
                    FechaInicio,
                    FechaFinalizacion,
                    Descripcion,
                    Estado,
                    IdPrograma,
                    IdJornada
                )
                VALUES
                (
                    @CodigoFicha,
                    @FechaInicio,
                    @FechaFinalizacion,
                    @Descripcion,
                    @Estado,
                    @IdPrograma,
                    @IdJornada
                )";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@CodigoFicha", f.CodigoFicha);
                cmd.Parameters.AddWithValue("@FechaInicio", f.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", f.FechaFinalizacion);
                cmd.Parameters.AddWithValue("@Descripcion", f.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", f.Estado);
                cmd.Parameters.AddWithValue("@IdPrograma", f.IdPrograma);
                cmd.Parameters.AddWithValue("@IdJornada", f.IdJornada);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
                   UPDATE Ficha
                      SET Activo = 0
                        WHERE IdFicha = @IdFicha";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdFicha", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Fichas f)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        UPDATE Ficha
        SET
            CodigoFicha = @CodigoFicha,
            FechaInicio = @FechaInicio,
            FechaFinalizacion = @FechaFinalizacion,
            Descripcion = @Descripcion,
            Estado = @Estado,
            IdPrograma = @IdPrograma,
            IdJornada = @IdJornada
        WHERE IdFicha = @IdFicha";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@IdFicha", f.IdFicha);
                cmd.Parameters.AddWithValue("@CodigoFicha", f.CodigoFicha);
                cmd.Parameters.AddWithValue("@FechaInicio", f.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFinalizacion", f.FechaFinalizacion);
                cmd.Parameters.AddWithValue("@Descripcion", f.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", f.Estado);
                cmd.Parameters.AddWithValue("@IdPrograma", f.IdPrograma);
                cmd.Parameters.AddWithValue("@IdJornada", f.IdJornada);

                cmd.ExecuteNonQuery();
            }
        }

        public int ObtenerIdPorCodigo(
    string codigoFicha)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT IdFicha
        FROM Ficha
        WHERE CodigoFicha =
              @CodigoFicha";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@CodigoFicha",
                    codigoFicha);

                object resultado =
                    cmd.ExecuteScalar();

                if (resultado == null)
                    return 0;

                return Convert.ToInt32(resultado);
            }
        }
    }
}