using PlanMejoramiento.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlanMejoramiento.Modelo;

namespace PlanMejoramiento.Logica
{
    public class GestionAcademicaL
    {
        GestionAcademicaD dao =
           new GestionAcademicaD();

        public List<GestionAcademica> Listar()
        {
            return dao.Listar();
        }

        public void Insertar(
            GestionAcademica g)
        {
            dao.Insertar(g);
        }

        public void Eliminar(int id)
        {
            dao.Eliminar(id);
        }

        public int ObtenerIdPorUsuario(
    int idUsuario)
        {
            return dao.ObtenerIdPorUsuario(
                idUsuario);
        }
    }
}