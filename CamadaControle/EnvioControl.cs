using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VIII.VO;
using PIM_VIII.Model;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace PIM_VIII.Control
{
    public class EnvioControl
    {

        public void EnviarAtividadeByAluno(int idCronograma, Aluno _aluno, string observacoes, HttpPostedFile file = null)
        {
            var _cronograma = new CronogramaDAL().GetById(idCronograma);

            if (_cronograma.DataFim < DateTime.Now)
                throw new Exception("Atividade não pode ser enviada pois está fora do prazo de entrega.");

            var _envio = new EnvioControl().GetEnvioByIdCronogramaAluno(_cronograma.Id, _aluno);

            Envio envio = new Envio()
            {
                aluno = _aluno,
                cronograma = _cronograma,
                DataEnvio = DateTime.Now,
                ObsAluno = observacoes
            };

            if (_envio != null)
            {
                _envio.ObsAluno = observacoes;
                _envio.DataEnvio = DateTime.Now;
                new EnvioDAL().Atualiza(_envio);
            }
            else
            {
                _envio = envio;
                _envio.Id = new EnvioDAL().InsereId(envio);
            }

            if(file != null)
            {
                try
                {
                    string pathFile = this.SalvarAnexo(file);
                    if (!String.IsNullOrEmpty(pathFile))
                    {
                        int idAnexo = new AnexoDAL().InsereId(new Anexo { NomeArquivo = pathFile });
                        _envio.anexo = new Anexo() { Id = idAnexo, NomeArquivo = pathFile };
                        new EnvioDAL().AtualizaEnvioByAnexo(_envio);
                    }
                }
                catch (Exception) {}
            }
        }

        public List<Envio> GetAllEnviosByIdCronogramaProfessor(int idCronograma, Professor professor)
        {
            return new EnvioDAL().GetAll().Where(x => x.cronograma.disciplina.Id == professor.disciplina.Id)
                .Where(x=> x.cronograma.Id == idCronograma).ToList();
        }

        public Envio GetEnvioByIdCronogramaAluno(int idCronograma, Aluno aluno)
        {
            return new EnvioDAL().GetAll().Where(x => x.aluno != null && x.aluno.Matricula == aluno.Matricula)
                .Where(x => x.cronograma.Id == idCronograma).FirstOrDefault();
        }

        public Envio GetEnvioByIdCronogramaProfessor(int IdEnvio, Professor professor)
        {
            return new EnvioDAL().GetAll().Where(x => x.cronograma.disciplina.Id == professor.disciplina.Id)
                .Where(x => x.Id == IdEnvio).FirstOrDefault();
        }

        public void EnviarAtividadeByProfessor(int idEnvio, Professor professor, int nota, string observacoes)
        {
            try
            {
                var _envio = new EnvioControl().GetEnvioByIdCronogramaProfessor(idEnvio, professor);

                _envio.ObsProfessor = observacoes;
                _envio.DataCorrecao= DateTime.Now;
                _envio.nota = nota;

                new EnvioDAL().Atualiza(_envio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SalvarAnexo(HttpPostedFile arquivo)
        {
            try
            {
                string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Arquivos");
                string fileName = arquivo.FileName;
                string pathToCheck = Path.Combine(savePath, fileName);
                string tempfileName = "";
                if (File.Exists(pathToCheck))
                {
                    int counter = 2;
                    while (File.Exists(pathToCheck))
                    {
                        tempfileName = counter.ToString() + fileName;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }
                    fileName = tempfileName;
                }
                savePath = Path.Combine(savePath, fileName);
                arquivo.SaveAs(savePath);
                return savePath;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public Envio GetEnvioByIdCronogramaMatriculaAluno(int id, string matricula)
        {
            return new EnvioDAL().GetAll().Where(x => x.cronograma.Id == id)
                .Where(x => x.aluno.Matricula == matricula).FirstOrDefault();
        }
    }
}
