using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Model
{
    public class mdlDisciplina : IConnection
    {

        public System.Data.OleDb.OleDbConnection GetDBConnection()
        {
            return new OleDbConnection { ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\FRANCILUCIA\Desktop\FRANCI\dbPIM_VIII.accdb" };
        }

        public void CloseDbConnection()
        {
            throw new NotImplementedException();
        }

        public static int GetMax()
        {
            int result = 0;
            string sqlQuery = "SELECT MAX(ID_DISCIPLINA) FROM tbl_disciplinas";
            try
            {
                using (var conexao = new mdlCurso().GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        conexao.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception) { return -1; }

            return ++result;
        }

        public static int Insere(string Disciplina, int idCurso, int idAtividade)
        {
            string SqlString = "Insert Into tbl_disciplinas (ID_DISCIPLINA, DISCIPLINA, ID_CURSO, ID_ATIVIDADE) Values (?,?,?,?)";
            int idMax = GetMax();
            using (var conexao = new mdlCurso().GetDBConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID_DISCIPLINA", idMax);
                    cmd.Parameters.AddWithValue("DISCIPLINA", Disciplina);
                    cmd.Parameters.AddWithValue("ID_CURSO", idCurso);
                    cmd.Parameters.AddWithValue("ID_ATIVIDADE", idAtividade);
                    conexao.Open();
                    cmd.ExecuteNonQuery();

                    return idMax;
                }   
            }
        }
    }
}
