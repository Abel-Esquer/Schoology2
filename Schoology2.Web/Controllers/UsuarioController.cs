using Schoology2.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoology2.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuarios = Usuario.GetAll();
            return View(usuarios);
        }

        public ActionResult Registro(int id)
        {
            Usuario usuario = Usuario.GetById(id);
            return View(usuario);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string correo, string contraseña, string rol)
        {
            Usuario.Guardar(id, nombre, apellido, correo, contraseña, rol);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Usuario.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}