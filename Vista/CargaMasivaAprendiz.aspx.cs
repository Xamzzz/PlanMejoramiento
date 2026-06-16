using ExcelDataReader;
using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlanMejoramiento.Vista
{
    public partial class CargaMasivaAprendiz : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            ImportarExcel();
        }

        private void ImportarExcel()
        {
            try
            {
                if (!fuExcel.HasFile)
                {
                    lblMensaje.Text = "Seleccione un archivo Excel.";
                    return;
                }

                string path = Server.MapPath("~/Temp/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string filePath = Path.Combine(path, fuExcel.FileName);
                fuExcel.SaveAs(filePath);

                DataTable tabla;

                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    tabla = reader.AsDataSet().Tables[0];
                }

                List<Modelo.Aprendiz> lista = new List<Modelo.Aprendiz>();
                List<string> errores = new List<string>();

                AprendizD aprendizD = new AprendizD();
                TipoDocumentoD tipoD = new TipoDocumentoD();
                EstadoAprendizD estadoD = new EstadoAprendizD();

                for (int i = 1; i < tabla.Rows.Count; i++)
                {
                    string documento = tabla.Rows[i][1].ToString().Trim();

                    if (string.IsNullOrWhiteSpace(documento))
                    {
                        errores.Add($"Fila {i}: Documento vacío");
                        continue;
                    }

                    if (aprendizD.ExisteDocumento(documento))
                    {
                        errores.Add($"Fila {i}: Ya existe ({documento})");
                        continue;
                    }

                    lista.Add(new Modelo.Aprendiz
                    {
                        IdTipoDocumento = tipoD.ObtenerIdPorNombre(tabla.Rows[i][0].ToString()),
                        NumeroDocumento = documento,
                        Nombres = tabla.Rows[i][2].ToString(),
                        Apellidos = tabla.Rows[i][3].ToString(),
                        Correo = tabla.Rows[i][4].ToString(),
                        Telefono = tabla.Rows[i][5].ToString(),
                        IdEstadoAprendiz = estadoD.ObtenerIdEnFormacion(),
                    });
                }

                if (errores.Count > 0)
                {
                    lblMensaje.Text =
                        "No se puede importar. Corrige el archivo primero.<br/>" +
                        string.Join("<br/>", errores);
                    return;
                }

                GuardarEnBD(lista);

                lblMensaje.Text = "Importación exitosa ✔";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
        private void GuardarEnBD(List<Modelo.Aprendiz> lista)
        {
            using (SqlConnection cn = ConexionDB.MtAbrirConexion())
            {
                cn.Open();
                SqlTransaction tx = cn.BeginTransaction();

                try
                {
                    AprendizD aprendizD = new AprendizD();
                    UsuarioD usuarioD = new UsuarioD();
                    FichaD fichaD = new FichaD();
                    AprendizFichaD relacionD = new AprendizFichaD();

                    foreach (var a in lista)
                    {
                        Usuario u = new Usuario
                        {
                            NombreUsuario = a.NumeroDocumento,
                            Clave = a.NumeroDocumento,
                            IdRol = 3,
                            Estado = true
                        };

                        //    int idUsuario = usuarioD.InsertarRetornandoId();
                        //    a.IdUsuario = idUsuario;

                        //    int idAprendiz = aprendizD.InsertarRetornandoId(a, cn, tx);

                        //    int idFicha = fichaD.ObtenerIdPorCodigo(a.CodigoFicha);

                        //    if (idFicha <= 0)
                        //        throw new Exception("Ficha no existe: " + a.CodigoFicha);

                        //    relacionD.InsertarMasivo(idAprendiz, idFicha, cn, tx);
                        //}

                        //tx.Commit();
                    }
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }
    }
}

