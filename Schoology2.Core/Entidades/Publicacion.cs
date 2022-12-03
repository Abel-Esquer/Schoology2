using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Publicacion
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicado { get; set; }
        public DateTime FechaActualiado { get; set; }
        public Curso IdCurso { get; set; }
    }
}
