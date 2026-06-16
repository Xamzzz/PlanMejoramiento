using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Datos
{
    public class GestionAcademicaD
    {
        public List<GestionAcademica> Listar()
        {
            List<GestionAcademica> lista =
                new List<GestionAcademica>();

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

SELECT

    G.*,

    TD.Nombre AS TipoDocumento,

    U.Usuario

FROM GestionAcademica G

INNER JOIN TipoDocumento TD
ON G.IdTipoDocumento =
   TD.IdTipoDocumento

INNER JOIN Usuario U
ON G.IdUsuario =
   U.IdUsuario

WHERE G.Activo = 1";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    GestionAcademica g =
                        new GestionAcademica();

                    g.IdGestionAcademica =
                        Convert.ToInt32(
                            dr["IdGestionAcademica"]);

                    g.IdTipoDocumento =
                        Convert.ToInt32(
                            dr["IdTipoDocumento"]);

                    g.NumeroDocumento =
                        dr["NumeroDocumento"].ToString();

                    g.Nombres =
                        dr["Nombres"].ToString();

                    g.Apellidos =
                        dr["Apellidos"].ToString();

                    g.Correo =
                        dr["Correo"].ToString();

                    g.Telefono =
                        dr["Telefono"].ToString();

                    g.IdUsuario =
                        Convert.ToInt32(
                            dr["IdUsuario"]);

                    g.Activo =
                        Convert.ToBoolean(
                            dr["Activo"]);

                    g.TipoDocumento =
                        dr["TipoDocumento"].ToString();

                    g.Usuario =
                        dr["Usuario"].ToString();

                    lista.Add(g);
                }
            }

            return lista;
        }

        public void Insertar(
            GestionAcademica g)
        {
            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"

INSERT INTO GestionAcademica
(
    IdTipoDocumento,
    NumeroDocumento,
    Nombres,
    Apellidos,
    Correo,
    Telefono,
    IdUsuario,
    Activo
)

VALUES
(
    @IdTipoDocumento,
    @NumeroDocumento,
    @Nombres,
    @Apellidos,
    @Correo,
    @Telefono,
    @IdUsuario,
    1
)";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@IdTipoDocumento",
                    g.IdTipoDocumento);

                cmd.Parameters.AddWithValue(
                    "@NumeroDocumento",
                    g.NumeroDocumento);

                cmd.Parameters.AddWithValue(
                    "@Nombres",
                    g.Nombres);

                cmd.Parameters.AddWithValue(
                    "@Apellidos",
                    g.Apellidos);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    g.Correo);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    g.Telefono);

                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    g.IdUsuario);

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

UPDATE GestionAcademica
SET Activo = 0
WHERE IdGestionAcademica =
      @Id";

                SqlCommand cmd =
                    new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue(
                    "@Id",
                    id);

                cmd.ExecuteNonQuery();
            }
        }

        public int ObtenerIdPorUsuario(
    int idUsuario)
        {
            int id = 0;

            using (SqlConnection cn =
                ConexionDB.MtAbrirConexion())
            {
                cn.Open();

                string sql = @"
        SELECT IdGestionAcademica
        FROM GestionAcademica
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
                    id = Convert.ToInt32(
                        resultado);
                }
            }

            return id;
        }
    }
}