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
        public List<Envio> GetAllEnviosByAluno(Aluno aluno)
        {
            return new EnvioDAL().GetByAluno(aluno);
        }

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

        public List<Envio> GetEnvioByAluno(Aluno aluno)
        {
            return new EnvioDAL().GetByAluno(aluno);
        }

        public Envio GetEnvioByIdCronogramaAluno(int idCronograma, Aluno aluno)
        {
            return GetEnvioByAluno(aluno).Where(x => x.cronograma.Id == idCronograma).FirstOrDefault();
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
