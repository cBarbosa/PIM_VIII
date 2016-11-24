using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VIII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class CursoDAL : IConnection<PIM_VIII.VO.Curso>
    {
        const string _TABLE = "tbl_curso";
        const string _SELECT_ALL = @"SELECT ID_CURSO, CURSO
                                    FROM tbl_curso";
        const string _SELECT_ID = @"SELECT ID_CURSO, CURSO
                                    FROM tbl_curso WHERE ID_CURSO = ?";

        private static OleDbConnection GetDBConnection()
        {
            try
            {
                return new OleDbConnection { ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringAccess"].ConnectionString.ToString() };
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro: '{0}'", ex.Message));
            }
        }

        public void Atualiza(Curso Curso)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public List<Curso> GetAll()
        {
            List<Curso> result = new List<Curso>();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ALL, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var aluno = new Curso
                                    {
                                        Id = reader.GetInt32(0),
                                        Nome = reader.GetString(1),
                                    };
                                    result.Add(aluno);
                                }
                            }
                            else { result = null; }
                        }
                    }
                }
                return result;
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Não foi possível consultar o registro na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public Curso GetById(int id)
        {
            Curso result = new Curso();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_CURSO", id);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Curso
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1)
                                };
                            }
                            else { result = null; }
                        }
                    }
                }
                return result;
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Não foi possível consultar o registro na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public void Insere(Curso Curso)
        {
            throw new NotImplementedException();
        }
    }
}
