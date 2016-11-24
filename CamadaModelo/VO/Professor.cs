using System;

namespace PIM_VIII.VO
{
    [Serializable]
    public class Professor : Pessoa
    {
        public string Matricula { get; set; }
        public Disciplina disciplina { get; set; }
    }
}
