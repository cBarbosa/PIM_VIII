using PIM_VIII.VO;
using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Control
{
    public class ProfessorControl
    {
        public List<Professor> GetAllProfessores()
        {
            return new ProfessorDAL().GetAll();
        }

        public void AtualizarProfessor(string nome, string matricula, double cpf, int rg, DateTime data, int disciplina)
        {
            var professor = new Professor()
            {
                Nome = nome,
                Matricula = matricula,
                CPF = cpf,
                RG = rg,
                DataNascimento = data,
                disciplina = new Disciplina()
                {
                    Id = disciplina
                }
            };
            new ProfessorDAL().Atualiza(professor);
        }

        public void InsereProfessor(string nome, string matricula, double cpf, int rg, DateTime data, int disciplina)
        {
            var professor = new Professor()
            {
                Nome = nome,
                Matricula = matricula,
                CPF = cpf,
                RG = rg,
                DataNascimento = data,
                disciplina = new Disciplina()
                {
                    Id = disciplina
                }
            };
            new ProfessorDAL().Insere(professor);
        }

        public void ExcluiProfessor(string matricula)
        {
            new ProfessorDAL().ExcluiByMatricula(matricula);
        }
    }
}
