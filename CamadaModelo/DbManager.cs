using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Model
{
    public interface IConnection
    {
        //OleDbConnection _dbConnection;

        OleDbConnection GetDBConnection();

        void CloseDbConnection();

        /*
        public OleDbConnection OpenDbConnection()
        {
            _dbConnection = new OleDbConnection { ConnectionString = GetConnectionString() };
            return _dbConnection;
        }

        public static OleDbConnection GetDbConnection()
        {
            return new OleDbConnection { ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\FRANCILUCIA\Desktop\FRANCI\dbPIM_VIII.accdb" };
        }

        private string GetConnectionString()
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\FRANCILUCIA\Desktop\FRANCI\dbPIM_VIII.accdb";
        }

        public void CloseDbConnection()
        {
            _dbConnection.Close();
        }*/

    }
}