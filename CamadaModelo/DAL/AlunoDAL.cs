using System;
using System.Collections.Generic;
using PIM_VII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class AlunoDAL : IConnection<PIM_VII.VO.Aluno>
    {
        const string _TABLE = "tbl_usuario";
        const string _SELECT_MATRICULA = @"SELECT MATRICULA, NOME, SENHA, CPF, RG, DATANASCIMENTO, tbl_curso.ID_CURSO, CURSO
                                    FROM tbl_usuario
                                    INNER JOIN tbl_curso ON tbl_usuario.ID_CURSO = tbl_curso.ID_CURSO
                                    WHERE MATRICULA = ? AND PERFIL = '3' AND tbl_usuario.ID_CURSO IS NOT NULL";

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

        public void Atualiza(Aluno obj)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> GetAll()
        {
            throw new NotImplementedException();
        }

        public Aluno GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Aluno obj)
        {
            throw new NotImplementedException();
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
                                    CursoMatriculado = new Curso()
                                    {
                                        Id = reader.GetInt32(6),
                                        Nome = reader.GetString(7)
                                    }
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