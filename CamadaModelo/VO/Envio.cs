using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.VO
{
    [Serializable]
    public class Envio
    {
        public int Id { get; set; }
        public int nota { get; set; }
        public DateTime DataEnvio { get; set; }
        public DateTime DataCorrecao { get; set; }
        public string ObsAluno { get; set; }
        public string ObsProfessor { get; set; }
        public Cronograma cronograma{ get; set; }
        public Aluno aluno { get; set; }
    }
}