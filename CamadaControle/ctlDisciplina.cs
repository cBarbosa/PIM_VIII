using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;

namespace PIM_VIII.Control
{
    public class ctlDisciplina
    {
        public static bool InsertDisciplina(Disciplina disciplina)
        {
            var retorno = PIM_VIII.Model.mdlDisciplina.Insere(disciplina.Nome,
                disciplina.IdCurso,
                disciplina.IdAtividade);

            return false;
        }
    }
}
