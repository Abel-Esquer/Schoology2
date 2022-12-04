using Schoology2.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoology2.Web.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index()
        {
            List<Comentario> comentarios = Comentario.GetAll();
            return View(comentario);
        }

        public ActionResult Registro(int id)
        {
            Comentario comentario = Comentario.GetById(id);
            return View();
        }
    }
}