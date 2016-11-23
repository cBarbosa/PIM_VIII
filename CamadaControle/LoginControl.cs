using PIM_VII.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

            SetCookie(_pessoa);

            return _pessoa;
        }

        private void SetCookie(Pessoa usuario)
        {
            try
            {
                HttpCookie cookie = new HttpCookie("ProjetoTCC");
                cookie.Value = SerializeUser(usuario);
                cookie.Expires = DateTime.Now.AddHours(2);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string SerializeUser(Pessoa _usuario)
        {
            MemoryStream stream = null;
            string retorno = string.Empty;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stream = new MemoryStream();
                formatter.Serialize(stream, _usuario);

                retorno = Convert.ToBase64String(stream.ToArray());
            }
            catch
            {
                throw;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return retorno;
        }

        public static Pessoa GetDadosAutenticados(HttpCookie httpCookie)
        {
            HttpCookie cookie = httpCookie;
            Pessoa usuario = null;

            if (cookie != null)
            {
                MemoryStream stream = null;
                BinaryFormatter formatter = null;

                try
                {
                    stream = new MemoryStream(Convert.FromBase64String(cookie.Value));
                    formatter = new BinaryFormatter();
                    usuario = (Pessoa)formatter.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }
            return usuario;
        }

        public static PerfilAcesso GetPerfilUsuarioLogado(HttpCookie httpCookie)
        {
            PerfilAcesso result = PerfilAcesso.Nenhum;
            if (httpCookie == null)
                return result;

            if (GetDadosAutenticados(httpCookie).GetType().Equals(typeof(Atendente)))
            {
                result = PerfilAcesso.Atendente;
            } else if (GetDadosAutenticados(httpCookie).GetType().Equals(typeof(Professor)))
            {
                result = PerfilAcesso.Professor;
            } else if (GetDadosAutenticados(httpCookie).GetType().Equals(typeof(Aluno)))
            {
                result = PerfilAcesso.Aluno;
            }
            return result;
        }
    }

    public enum PerfilAcesso
    {
        Nenhum = '0',
        Atendente = '1',
        Professor = '2',
        Aluno = '3'
    }
}
