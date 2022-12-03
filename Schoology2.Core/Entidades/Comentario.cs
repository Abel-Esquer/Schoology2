using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public Usuario Alumno { get; set; }
        public DateTime FechaPublicado { get; set; }
        public DateTime FechaActualizado { get; set; }
        public Publicacion IdPublicacion { get; set; }

    }
}
