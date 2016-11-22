using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIM_VII.VO
{
    [Serializable]
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Curso curso { get; set; }
        //public Atividade atividade { get; set; }
    }
}