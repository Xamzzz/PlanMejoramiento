using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class TipoDocumentoL
    {
        TipoDocumentoD datos =
            new TipoDocumentoD();

        public List<TipoDocumento> Listar()
        {
            return datos.Listar();
        }
    }
}