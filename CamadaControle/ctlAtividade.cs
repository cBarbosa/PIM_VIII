using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Control
{
    public class ctlAtividade
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
    }
}
