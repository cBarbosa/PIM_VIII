using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Model
{
    public class mdlCurso : IConnection
    {

        public OleDbConnection GetDBConnection()
        {
            return new OleDbConnection { ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\FRANCILUCIA\Desktop\FRANCI\dbPIM_VIII.accdb" };
        }

        public void CloseDbConnection()
        {
            throw new NotImplementedException();
        }

        public System.Data.OleDb.OleDbConnection OpenDbConnection()
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public static DataSet GetAll()
        {
            DataSet DataCurso = new DataSet();

            try
            {
                using (var conexao = new mdlCurso().GetDBConnection())
                {
                    var myAdapptor = new OleDbDataAdapter();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM tbl_curso", conexao);
                    myAdapptor.SelectCommand = command;
                    myAdapptor.Fill(DataCurso, "tbl_curso");

                    return DataCurso;
                }
            }
            catch (Exception) { return null; }
        }
    }
}
