using System;
using System.Collections.Generic;
using PIM_VIII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class AlunoDAL : IConnection<PIM_VIII.VO.Aluno>
    {
        const string _TABLE = "tbl_usuario";
        const string _SELECT_MATRICULA = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, ID_CURSO
                                    FROM tbl_usuario
                                    WHERE MATRICULA = ? AND PERFIL = '3' AND tbl_usuario.ID_CURSO IS NOT NULL";
        const string _SELECT_ALL = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, ID_CURSO
                                    FROM tbl_usuario
                                    WHERE PERFIL = '3'";
        const string _UPDATE_MATRICULA = @"UPDATE tbl_usuario SET MATRICULA = ?, NOME =?, CPF = ?, RG = ?, DATANASCIMENTO = ?, ID_CURSO = ?
                                    WHERE MATRICULA = ? AND PERFIL = '3' AND tbl_usuario.ID_CURSO IS NOT NULL";
        const string _INSERT = @"INSERT INTO tbl_usuario (MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, ID_CURSO, PERFIL)
                                    VALUES(?, ?, '123456', ?, ?, ?, ?, '3')";
        const string _DELETE_MATRICULA = @"DELETE FROM tbl_usuario WHERE MATRICULA = ? AND PERFIL = '3'";

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

        public void Atualiza(Aluno aluno)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE_MATRICULA, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", aluno.Matricula);
                        cmd.Parameters.AddWithValue("NOME", aluno.Nome);
                        cmd.Parameters.AddWithValue("CPF", aluno.CPF);
                        cmd.Parameters.AddWithValue("RG", aluno.RG);
                        cmd.Parameters.AddWithValue("DATANASCIMENTO", aluno.DataNascimento);
                        cmd.Parameters.AddWithValue("ID_CURSO", aluno.CursoMatriculado.Id);
                        cmd.Parameters.AddWithValue("MATRICULA", aluno.Matricula);
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

        public List<Aluno> GetAll()
        {
            List<Aluno> result = new List<Aluno>();

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
                                    var aluno = new Aluno
                                    {
                                        Matricula = reader.GetString(0),
                                        Nome = reader.GetString(1),
                                        Senha = reader.GetString(2),
                                        CPF = reader.GetDouble(3),
                                        RG = reader.GetInt32(4),
                                        DataNascimento = reader.GetDateTime(5),
                                        CursoMatriculado = new CursoDAL().GetById(reader.GetInt32(6))
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

        public Aluno GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Aluno aluno)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", aluno.Matricula);
                        cmd.Parameters.AddWithValue("NOME", aluno.Nome);
                        cmd.Parameters.AddWithValue("CPF", aluno.CPF);
                        cmd.Parameters.AddWithValue("RG", aluno.RG);
                        cmd.Parameters.AddWithValue("DATANASCIMENTO", aluno.DataNascimento);
                        cmd.Parameters.AddWithValue("ID_CURSO", aluno.CursoMatriculado.Id);
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

        public Aluno GetByMatricula(string matricula)
        {
            Aluno result = new Aluno();

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
                                result = new Aluno
                                {
                                    Matricula = reader.GetString(0),
                                    Nome = reader.GetString(1),
                                    Senha = reader.GetString(2),
                                    CPF = reader.GetDouble(3),
                                    RG = reader.GetInt32(4),
                                    DataNascimento = reader.GetDateTime(5),
                                    CursoMatriculado = new CursoDAL().GetById(reader.GetInt32(6))
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

        public void ExcluiByMatricula(string matricula)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_DELETE_MATRICULA, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("MATRICULA", matricula);
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
    }
}