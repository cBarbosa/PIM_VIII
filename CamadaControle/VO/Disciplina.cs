using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIM_VII.VO
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCurso { get; set; }
        public int IdAtividade { get; set; }
    }
}