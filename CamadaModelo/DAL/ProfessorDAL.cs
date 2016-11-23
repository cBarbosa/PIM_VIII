using System;
using System.Collections.Generic;
using PIM_VII.VO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace PIM_VIII.Model
{
    public class ProfessorDAL : IConnection<PIM_VII.VO.Professor>
    {
        const string _TABLE = "tbl_usuario";
        const string _SELECT_MATRICULA = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, tbl_disciplinas.ID_DISCIPLINA
                                    FROM tbl_usuario
                                    INNER JOIN tbl_disciplinas ON tbl_usuario.ID_DISCIPLINA = tbl_disciplinas.ID_DISCIPLINA
                                    WHERE MATRICULA = ? AND PERFIL = '2'";

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

        public void Atualiza(Professor obj)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public List<Professor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Professor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Professor obj)
        {
            throw new NotImplementedException();
        }

        public Professor GetByMatricula(string matricula)
        {
            Professor result = new Professor();

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
                                result = new Professor
                                {
                                    Matricula = reader.GetString(0),
                                    Nome = reader.GetString(1),
                                    Senha = reader.GetString(2),
                                    CPF = reader.GetDouble(3),
                                    RG = reader.GetInt32(4),
                                    DataNascimento = reader.GetDateTime(5),
                                    disciplina = reader[6] == DBNull.Value ? null : new DisciplinaDAL().GetById(reader.GetInt32(6))
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