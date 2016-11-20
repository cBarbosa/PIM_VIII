using PIM_VII.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Control
{
    public class LoginControl
    {
        //public 
        public Pessoa ValidaLogin(string matricula, string senha)
        {
            Pessoa _pessoa = null;
            try
            {
                #region tratamento para login de atendente
                _pessoa = new PIM_VIII.Model.AtendenteDAL().GetByMatricula(matricula);
                #endregion

                #region tratamento para login de professor
                if (_pessoa == null)
                    _pessoa = new PIM_VIII.Model.ProfessorDAL().GetByMatricula(matricula);
                #endregion

                #region tratamento para login do aluno
                if (_pessoa == null)
                    _pessoa = new PIM_VIII.Model.AlunoDAL().GetByMatricula(matricula);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region tratamento de validação de login
            if (_pessoa == null)
                throw new Exception("Usuário não encontrado.");
            else
            {
                    if (!_pessoa.Senha.Equals(senha))
                        throw new Exception("Senha não confere");
            }
            #endregion

            return _pessoa;
        }
    }
}
