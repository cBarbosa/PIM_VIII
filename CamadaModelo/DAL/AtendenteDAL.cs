using System;
using System.Collections.Generic;
using PIM_VII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class AtendenteDAL : IConnection<PIM_VII.VO.Atendente>
    {
        const string _TABLE = "tbl_usuario";
        const string _SELECT_MATRICULA = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO
                                    FROM tbl_usuario WHERE MATRICULA = ? AND PERFIL = '1'";

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

        public void Atualiza(Atendente obj)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public List<Atendente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Atendente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Atendente obj)
        {
            throw new NotImplementedException();
        }

        public Atendente GetByMatricula(string matricula)
        {
            Atendente result = new Atendente();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_MATRICULA, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", matricula);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Atendente
                                {
                                    Matricula = reader.GetString(0),
                                    Nome = reader.GetString(1),
                                    Senha = reader.GetString(2),
                                    CPF = reader.GetDouble(3),
                                    RG = reader.GetInt32(4),
                                    DataNascimento = reader.GetDateTime(5)
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
    }
}
