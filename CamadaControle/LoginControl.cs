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
        public Atendente ValidaLogin(string matricula, string senha)
        {
            Atendente atendente;
            try
            {
                atendente = new PIM_VIII.Model.AtendenteDAL().GetByMatricula(matricula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            if (atendente == null)
                throw new Exception("Atendente não encontrado.");

            if (!atendente.Senha.Equals(senha))
                throw new Exception("Senha não confere");

            return atendente;
        }
    }
}
