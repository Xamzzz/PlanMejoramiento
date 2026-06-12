using ExcelDataReader;
using PlanMejoramiento.Datos;
using System;
using System.Collections.Generic;
using System.Data;
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

        protected void btnImportar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!fuExcel.HasFile)
                {
                    lblMensaje.Text =
                        "Seleccione un archivo Excel.";

                    return;
                }

                string carpetaTemp =
                    Server.MapPath("~/Temp/");

                if (!Directory.Exists(carpetaTemp))
                {
                    Directory.CreateDirectory(
                        carpetaTemp);
                }

                string rutaArchivo =
                    Path.Combine(
                        carpetaTemp,
                        fuExcel.FileName);

                fuExcel.SaveAs(rutaArchivo);

                

                using (var stream =
                    File.Open(
                        rutaArchivo,
                        FileMode.Open,
                        FileAccess.Read))
                {
                    using (var reader =
                        ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet ds =
                            reader.AsDataSet();

                        DataTable tabla =
                            ds.Tables[0];

                        AprendizD aprendizD =
                            new AprendizD();

                        FichaD fichaD =
                            new FichaD();

                        AprendizFichaD relacionD =
                            new AprendizFichaD();

                        int registros =
                            0;

                        for (int i = 1;
                            i < tabla.Rows.Count;
                            i++)
                        {
                            Modelo.Aprendiz a =
                                new Modelo.Aprendiz();

                            a.IdTipoDocumento =
                                Convert.ToInt32(
                                    tabla.Rows[i][0]);

                            a.NumeroDocumento =
                                tabla.Rows[i][1].ToString();

                            a.Nombres =
                                tabla.Rows[i][2].ToString();

                            a.Apellidos =
                                tabla.Rows[i][3].ToString();

                            a.Correo =
                                tabla.Rows[i][4].ToString();

                            a.Telefono =
                                tabla.Rows[i][5].ToString();

                            a.IdEstadoAprendiz =
                                Convert.ToInt32(
                                    tabla.Rows[i][6]);

                            string usuarioExcel =
                                 tabla.Rows[i][7].ToString();

                            if (string.IsNullOrWhiteSpace(usuarioExcel))
                            {
                                a.IdUsuario = 0;
                            }
                            else
                            {
                                a.IdUsuario =
                                    Convert.ToInt32(usuarioExcel);
                            }

                            string codigoFicha =
                                tabla.Rows[i][8].ToString();

                            int idAprendiz =
                                aprendizD
                                .InsertarRetornandoId(a);

                            int idFicha =
                                fichaD
                                .ObtenerIdPorCodigo(
                                    codigoFicha);

                            if (idFicha > 0)
                            {
                                relacionD
                                .InsertarMasivo(
                                    idAprendiz,
                                    idFicha);

                                registros++;
                            }
                        }

                        lblMensaje.Text =
                            "Importación exitosa. Registros cargados: "
                            + registros;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text =
                    "Error: " +
                    ex.Message;
            }
        }
    }
}