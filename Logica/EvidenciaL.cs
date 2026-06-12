using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class EvidenciaL
    {
        EvidenciaD datos =
            new EvidenciaD();

        public List<Evidencia> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(Evidencia e)
        {
            datos.Insertar(e);
        }

        public void Eliminar(int id)
        {
            datos.Eliminar(id);
        }
    }
}