using System;
using System.Collections.Generic;
using PIM_VIII.VO;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace PIM_VIII.Model
{
    public class ProfessorDAL : IConnection<PIM_VIII.VO.Professor>
    {
        const string _TABLE = "tbl_usuario";
        const string _SELECT_MATRICULA = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, tbl_disciplinas.ID_DISCIPLINA
                                    FROM tbl_usuario
                                    INNER JOIN tbl_disciplinas ON tbl_usuario.ID_DISCIPLINA = tbl_disciplinas.ID_DISCIPLINA
                                    WHERE MATRICULA = ? AND PERFIL = '2'";
        const string _SELECT_ALL = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, tbl_disciplinas.ID_DISCIPLINA
                                    FROM tbl_usuario
                                    INNER JOIN tbl_disciplinas ON tbl_usuario.ID_DISCIPLINA = tbl_disciplinas.ID_DISCIPLINA
                                    WHERE PERFIL = '2'";
        const string _UPDATE_MATRICULA = @"UPDATE tbl_usuario SET MATRICULA = ?, NOME =?, CPF = ?, RG = ?, DATANASCIMENTO = ?, ID_DISCIPLINA = ?
                                    WHERE MATRICULA = ? AND PERFIL = '2'";
        const string _INSERT = @"INSERT INTO tbl_usuario (MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, ID_DISCIPLINA, PERFIL)
                                    VALUES(?, ?, '123456', ?, ?, ?, ?, '2')";

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

        public void Atualiza(Professor professor)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE_MATRICULA, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", professor.Matricula);
                        cmd.Parameters.AddWithValue("NOME", professor.Nome);
                        cmd.Parameters.AddWithValue("CPF", professor.CPF);
                        cmd.Parameters.AddWithValue("RG", professor.RG);
                        cmd.Parameters.AddWithValue("DATANASCIMENTO", professor.DataNascimento);
                        cmd.Parameters.AddWithValue("ID_CURSO", professor.disciplina.Id);
                        cmd.Parameters.AddWithValue("MATRICULA", professor.Matricula);
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

        public List<Professor> GetAll()
        {
            List<Professor> result = new List<Professor>();

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
                                    var professor = new Professor
                                    {
                                        Matricula = reader.GetString(0),
                                        Nome = reader.GetString(1),
                                        Senha = reader.GetString(2),
                                        CPF = reader.GetDouble(3),
                                        RG = reader.GetInt32(4),
                                        DataNascimento = reader.GetDateTime(5),
                                        disciplina = reader[6] == DBNull.Value ? null : new DisciplinaDAL().GetById(reader.GetInt32(6))
                                    };
                                    result.Add(professor);
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

        public Professor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Professor professor)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", professor.Matricula);
                        cmd.Parameters.AddWithValue("NOME", professor.Nome);
                        cmd.Parameters.AddWithValue("CPF", professor.CPF);
                        cmd.Parameters.AddWithValue("RG", professor.RG);
                        cmd.Parameters.AddWithValue("DATANASCIMENTO", professor.DataNascimento);
                        cmd.Parameters.AddWithValue("ID_CURSO", professor.disciplina.Id);
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