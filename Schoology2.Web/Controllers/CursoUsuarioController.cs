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
        public ActionResult RegistrarAlumno(int id)
        {
            ModeloCursoUsuario modelo = new ModeloCursoUsuario();
            modelo.Curso = Curso.GetById(id);
            modelo.Usuario = Usuario.GetAllAlumnos();
            modelo.CU = CursoUsuario.GetAll();
            return View(modelo);
        }

        public ActionResult Aniadir(int idCurso, int idAlumno)
        {
            CursoUsuario.Aniadir(idCurso, idAlumno);
            return RedirectToAction("Index","Curso");
        }

        public ActionResult Alumnado(int id)
        {
            List<CursoUsuario> CU = CursoUsuario.GetAlumnos(id);
            return View(CU);
        }

        public ActionResult Eliminar(int id)
        {
            CursoUsuario.Eliminar(id);
            return RedirectToAction("Index", "Curso");
        }
    }
}