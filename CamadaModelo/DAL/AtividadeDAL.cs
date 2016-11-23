using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using PIM_VII.VO;
using System.Linq;

namespace PIM_VIII.Model
{
    public class AtividadeDAL : IConnection<PIM_VII.VO.Atividade>
    {
        const string _TABLE = "tbl_atividades";
        const string _SELECT_ALL = @"SELECT ID_ATIVIDADE, ATIVIDADE
                                    FROM tbl_atividades";
        const string _SELECT_ID = @"SELECT ID_ATIVIDADE, ATIVIDADE
                                    FROM tbl_atividades WHERE ID_ATIVIDADE = ?";
        const string _INSERT = @"INSERT INTO tbl_atividades (ATIVIDADE)
                                    VALUES(?)";
        const string _UPDATE_ID = @"UPDATE tbl_atividades SET ATIVIDADE = ?
                                    WHERE ID_ATIVIDADE = ?";
        const string _DELETE_ID = @"DELETE FROM tbl_atividades WHERE ID_ATIVIDADE = ?";

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

        public List<Atividade> GetAll()
        {
            List<Atividade> result = new List<Atividade>();

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
                                    var _disciplina = new Atividade()
                                    {
                                        Id = reader.GetInt32(0),
                                        Nome = reader.GetString(1)
                                    };
                                    result.Add(_disciplina);
                                }
                            } else { result = null; }
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
                throw new Exception(String.Format("Não foi possível consultar os registrso na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public Atividade GetById(int id)
        {
            Atividade result = new Atividade();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_ATIVIDADE", id);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Atividade
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

        public void Insere(Atividade obj)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ATIVIDADE", obj.Nome);
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Não foi possível inserir o registro na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public void Atualiza(Atividade obj)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_ATIVIDADE", obj.Id);
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Não foi possível atualizar o registro na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public void Exclui(int id)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_DELETE_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_ATIVIDADE", id);
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException db)
            {
                throw new Exception(String.Format("Erro no banco de dados.\nErro: {0}", db.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Não foi possível excluir o registro na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public static DataSet GetAtividadesDataSet()
        {
            DataSet DataAtividades = new DataSet();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    var myAdapptor = new OleDbDataAdapter();
                    OleDbCommand command = new OleDbCommand(_SELECT_ALL, conexao);
                    myAdapptor.SelectCommand = command;
                    myAdapptor.Fill(DataAtividades, _TABLE);

                    return DataAtividades;
                }
            }
            catch (Exception) { return null; }
        }
    }
}
