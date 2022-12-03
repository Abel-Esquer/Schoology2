using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class CursoUsuario
    {
        public int Id { get; set; }
        public Curso IdCurso { get; set; }
        public Usuario IdAlumno { get; set; }

    }
}
