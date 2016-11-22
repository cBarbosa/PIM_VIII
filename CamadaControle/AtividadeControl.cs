using PIM_VII.VO;
using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
