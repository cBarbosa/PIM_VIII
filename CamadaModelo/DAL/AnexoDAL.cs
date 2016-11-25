using PIM_VIII.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_VIII.Model
{
    public class AnexoDAL : IConnection<Anexo>
    {
        const string _TABLE = "tbl_anexos";
        const string _INSERT = @"INSERT INTO tbl_anexos(ANEXO) VALUES(?)";
        const string _SELECT_ID = @"SELECT ID_ANEXO, ANEXO FROM tbl_anexos WHERE ID_ANEXO = ?";
        const string _SELECT_ALL = @"SELECT ID_ANEXO, ANEXO FROM tbl_anexos";
        const string _IDENTITY = "Select @@Identity";

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

        public void Atualiza(Anexo obj)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anexo> GetAll()
        {
            List<Anexo> result = new List<Anexo>();

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
                                    var _anexo = new Anexo()
                                    {
                                        Id = reader.GetInt32(0),
                                        NomeArquivo = reader.GetString(1)
                                    };
                                    result.Add(_anexo);
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
                throw new Exception(String.Format("Não foi possível consultar os registrso na tabela '{0}'.\nErro: '{1}'", _TABLE, ex.Message));
            }
        }

        public Anexo GetById(int id)
        {
            Anexo result = new Anexo();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_ANEXO", id);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Anexo
                                {
                                    Id = reader.GetInt32(0),
                                    NomeArquivo = reader.GetString(1)
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

        public void Insere(Anexo anexo)
        {
            throw new NotImplementedException();
        }

        public int InsereId(Anexo anexo)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ANEXO", anexo.NomeArquivo);
                        conexao.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = _IDENTITY;
                        return (int)cmd.ExecuteScalar();
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
    }
}
