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
    }
}