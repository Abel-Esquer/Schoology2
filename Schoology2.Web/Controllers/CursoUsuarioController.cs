using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Schoology2.Core.Entidades;

namespace Schoology2.Web.Controllers
{
    public class CursoUsuarioController : Controller
    {
        // GET: CursoUsuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Aniadir(int id, int idCurso, int idAlumno)
        {
            ModeloCursoProfesor modelo = new ModeloCursoProfesor();
            modelo.Curso = Curso.GetById(id);
            modelo.Alumno = Usuario.GetAllAlumnos();
            return View(modelo);
        }
    }

}