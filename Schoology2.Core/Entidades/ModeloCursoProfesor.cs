using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class ModeloCursoProfesor
    {
        public List<Usuario> Profesor { get; set; }
        public Curso Curso { get; set; }
    }
}
