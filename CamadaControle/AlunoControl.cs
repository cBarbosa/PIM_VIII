using System;
using System.Collections.Generic;
using PIM_VIII.VO;
using PIM_VIII.Model;

namespace PIM_VIII.Control
{
    public class AlunoControl
    {
        public List<Aluno> GetAllAlunos()
        {
            return new AlunoDAL().GetAll();
        }

        public void AtualizarAluno(string nome, string matricula, double cpf, int rg, DateTime data, int curso)
        {
            var aluno = new Aluno()
            {
                Nome = nome,
                Matricula = matricula,
                CPF = cpf,
                RG = rg,
                DataNascimento = data,
                CursoMatriculado = new Curso()
                {
                    Id = curso
                }
            };

            new AlunoDAL().Atualiza(aluno);
        }

        public void InsereAluno(string nome, string matricula, double cpf, int rg, DateTime data, int curso)
        {
            var aluno = new Aluno()
            {
                Nome = nome,
                Matricula = matricula,
                CPF = cpf,
                RG = rg,
                DataNascimento = data,
                CursoMatriculado = new Curso()
                {
                    Id = curso
                }
            };
            new AlunoDAL().Insere(aluno);
        }

        public void ExcluiAluno(string matricula)
        {
            new AlunoDAL().ExcluiByMatricula(matricula);
        }
    }
}
