using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VII.VO
{
    [Serializable]
    public class Cronograma
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public Atividade atividade { get; set; }
        public Disciplina disciplina { get; set; }
    }
}
