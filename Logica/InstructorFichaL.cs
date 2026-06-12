using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class InstructorFichaL
    {
        InstructorFichaD datos =
            new InstructorFichaD();

        public List<InstructorFicha> Listar()
        {
            return datos.Listar();
        }

        public void Insertar(InstructorFicha inf)
        {
            datos.Insertar(inf);
        }
    }
}