using PlanMejoramiento.Datos;
using PlanMejoramiento.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMejoramiento.Logica
{
    public class UsuarioL
    {
        UsuarioD dao =
            new UsuarioD();

        public Usuario Login(
            string usuario,
            string clave)
        {
            return dao.IniciarSesion(
                usuario,
                clave);
        }

        public List<Usuario> Listar()
        {
            return dao.Listar();
        }

        public void Insertar(Usuario u)
        {
            dao.Insertar(u);
        }

        public void Actualizar(Usuario u)
        {
            dao.Actualizar(u);
        }

        public void Eliminar(int id)
        {
            dao.Eliminar(id);
        }

        public int InsertarRetornandoId(Usuario u)
        {
            return dao.InsertarRetornandoId(u);
        }
    }
}