using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology2.Core.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        
        public Usuario idProfesor { get; set; }

    }
}
