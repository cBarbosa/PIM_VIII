using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;
using PIM_VIII.Model;
using System.Web;
using System.Web.UI.WebControls;

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
                new EnvioDAL().Insere(envio);
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

        private void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = "c:\\temp\\uploads\\";

            // Get the name of the file to upload.
            string fileName = file.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                throw new Exception("A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName);
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            file.SaveAs(savePath);

        }
    }
}
