using PIM_VIII.VO;
using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PIM_VIII.Control
{
    public class AtividadeControl
    {
        public static DataSet GetAllDataSetAtividade()
        {
            try
            {
                DataSet DataAtividade = PIM_VIII.Model.AtividadeDAL.GetAtividadesDataSet();
                return DataAtividade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Atividade> GetAllAtividades()
        {
            try
            {
                return new AtividadeDAL().GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Atividade> GetAllAtividadesProfessor()
        {
            return GetAllAtividades().Where(x => !x.Nome.Contains("Provas") && !x.Nome.Contains("Dependência")).ToList();
        }

        public List<Atividade> GetAllAtividadesAtendente()
        {
            return GetAllAtividades().Where(x => x.Nome.Contains("Provas") || x.Nome.Contains("Dependência")).ToList();
        }

        public void AtualizaAtividade(Atividade atividade)
        {
            new AtividadeDAL().Atualiza(atividade);
        }

        public void ExcluirAtividadeById(int id)
        {
            new AtividadeDAL().Exclui(id);
        }

        public void InsereAtividade(Atividade atividade)
        {
            new AtividadeDAL().Insere(atividade);
        }
    }
}
