using Schoology2.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoology2.Web.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            List<Curso> cursos = Curso.GetAll();
            return View(cursos);
        }
        public ActionResult Registro(int id)
        {
            Curso curso = Curso.GetById(id);
            return View(curso);
        }
        public ActionResult Guardar(int id, string nombre, string clave, int idProfesor)
        {
            Curso.Guardar(id, nombre, clave, idProfesor);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            Curso.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}