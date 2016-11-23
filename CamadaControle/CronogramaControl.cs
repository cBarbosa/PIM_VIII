using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;
using PIM_VIII.Model;

namespace PIM_VIII.Control
{
    public class CronogramaControl
    {
        public List<Cronograma> GetAllCronogramas()
        {
            return new CronogramaDAL().GetAll();
        }

        public List<Cronograma> GetAllCronogramaByProfessor(Professor professor)
        {
            return new CronogramaDAL().GetAll().Where(x => x.disciplina.Id == professor.disciplina.Id).ToList();
        }

        public Cronograma getCronogramaById(int id)
        {
            return new CronogramaDAL().GetById(id);
        }

        public void UpdateCronograma(int _id, int _atividade, int _disciplina, DateTime dataInicio, DateTime dataFinal)
        {
            var crono = new Cronograma()
            {
                Id = _id,
                atividade = new Atividade()
                {
                    Id = _atividade
                },
                disciplina = new Disciplina()
                {
                    Id = _disciplina
                },
                DataInicio = dataInicio,
                DataFim = dataFinal
            };

            new CronogramaDAL().Atualiza(crono);
        }

        public List<Cronograma> GetAllAtividadesByAluno(Aluno aluno)
        {
            try
            {
                return new CronogramaDAL().GetAllAtividadesByIdCurso(aluno.CursoMatriculado.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsereCronograma(int atividade, int disciplina, DateTime dataInicio, DateTime dataFinal)
        {
            try
            {
                var cronograma = new Cronograma()
                {
                    atividade = new AtividadeDAL().GetById(atividade),
                    disciplina = new DisciplinaDAL().GetById(disciplina),
                    DataInicio = dataInicio,
                    DataFim = dataFinal,
                };

                new CronogramaDAL().Insere(cronograma);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
