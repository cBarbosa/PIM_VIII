using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;
using PIM_VIII.Model;

namespace PIM_VIII.Control
{
    public class DisciplinaControl
    {
        public static bool InsertDisciplina(Disciplina disciplina)
        {
            /*
            var retorno = PIM_VIII.Model.mdlDisciplina.Insere(disciplina.Nome,
                disciplina.IdCurso,
                disciplina.IdAtividade);
                */
            return false;
        }

        public object GetAllDisciplinasByIdCurso(int id)
        {
            return GetAllByIdCurso(id);
        }

        public List<Disciplina> GetAllDisciplinas()
        {
            return new DisciplinaDAL().GetAll();
        }

        public List<Disciplina> GetAllByIdCurso(int id)
        {
            try
            {
                return GetAllDisciplinas().Where(x => x.curso.Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
