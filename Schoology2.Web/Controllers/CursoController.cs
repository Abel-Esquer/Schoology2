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
            ModeloCursoProfesor modelo = new ModeloCursoProfesor();
            modelo.Curso = Curso.GetById(id);
            modelo.Profesor = Usuario.GetAllProfesores();
            return View(modelo);
        }
        public ActionResult Guardar(int id, string curso, string clave, int idProfesor)
        {
            Curso.Guardar(id, curso, clave, idProfesor);
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            Curso.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}