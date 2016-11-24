using System;

namespace PIM_VIII.VO
{
    [Serializable]
    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }

        public Curso CursoMatriculado { get; set; }
    }
}
