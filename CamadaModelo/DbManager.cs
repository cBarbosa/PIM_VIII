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

    }
}