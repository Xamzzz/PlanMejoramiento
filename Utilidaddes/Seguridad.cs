using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Utilidaddes
{
    public class Seguridad
    {
        public static bool TieneRol(
      int rolPermitido)
        {
            if (HttpContext.Current
                .Session["IdRol"] == null)
            {
                return false;
            }

            return Convert.ToInt32(
                HttpContext.Current
                .Session["IdRol"])
                == rolPermitido;
        }
    }
}