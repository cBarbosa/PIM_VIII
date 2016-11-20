using System;
using System.Collections.Generic;
using PIM_VII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class PessoaDAL : IConnection<PIM_VII.VO.Pessoa>
    {
        const string _TABLE = "tbl_usuario";
        const string _UPDATE_CPF = @"UPDATE tbl_usuario
            SET NOME = ?, SENHA = ?, CPF = ?, RG = ?, DATANASCIMENTO = ? WHERE CPF = ?";

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

        public void Atualiza(Pessoa pessoa)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE_CPF, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("NOME", pessoa.Nome);
                        cmd.Parameters.AddWithValue("SENHA", pessoa.Senha);
                        cmd.Parameters.AddWithValue("CPF", pessoa.CPF);
                        cmd.Parameters.AddWithValue("RG", pessoa.RG);
                        cmd.Parameters.AddWithValue("DATANASCIMENTO", pessoa.DataNascimento);
                        cmd.Parameters.AddWithValue("CPF", pessoa.CPF);
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
            throw new NotImplementedException();
        }

        public List<Pessoa> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pessoa GetById(int cpf)
        {
            throw new NotImplementedException();
        }

        public void Insere(Pessoa obj)
        {
            throw new NotImplementedException();
        }
    }
}
