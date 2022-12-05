using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class ModeloCursoUsuario
    {
        public List<Usuario> Usuario { get; set; }
        public Curso Curso { get; set; }
        public List<CursoUsuario> CU { get; set; }
    }
}
