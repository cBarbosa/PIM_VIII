using PIM_VIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace PIM_VIII.Model
{
    public class EnvioDAL : IConnection<PIM_VII.VO.Envio>
    {
        const string _TABLE = "tbl_cadastro_envio";
        const string _SELECT_ALL = @"SELECT tbl_cronograma.ID_CRONOGRAMA,
                                tbl_usuario.MATRICULA,
                                tbl_cadastro_envio.[Código], tbl_cadastro_envio.DATA_ENVIO, tbl_cadastro_envio.DATA_CORRECAO, tbl_cadastro_envio.OBSERVACAO_ALUNO, tbl_cadastro_envio.OBSERVACAO_PROFESSOR, tbl_cadastro_envio.NOTA
                                FROM tbl_usuario RIGHT JOIN (tbl_curso INNER JOIN (tbl_disciplinas INNER JOIN (tbl_atividades INNER JOIN (tbl_cronograma LEFT JOIN tbl_cadastro_envio ON tbl_cronograma.ID_CRONOGRAMA = tbl_cadastro_envio.ID_CRONOGRAMA) ON tbl_atividades.ID_ATIVIDADE = tbl_cronograma.ID_ATIVIDADE) ON tbl_disciplinas.ID_DISCIPLINA = tbl_cronograma.ID_DISCIPLINA) ON tbl_curso.ID_CURSO = tbl_disciplinas.ID_CURSO) ON tbl_usuario.MATRICULA = tbl_cadastro_envio.MATRICULA
                                ORDER BY tbl_cadastro_envio.DATA_ENVIO DESC";
        const string _INSERT_ALUNO = @"INSERT INTO tbl_cadastro_envio (ID_CRONOGRAMA, MATRICULA, DATA_ENVIO, OBSERVACAO_ALUNO)
                                VALUES(?, ?, ?, ?)";
        const string _UPDATE = @"UPDATE tbl_cadastro_envio SET DATA_ENVIO = ?, OBSERVACAO_ALUNO = ?, DATA_CORRECAO = ?, NOTA = ?, OBSERVACAO_PROFESSOR = ?
                                WHERE [Código] = ?";

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

        public void Atualiza(Envio envio)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("DATA_ENVIO", envio.DataEnvio.ToShortDateString());
                        cmd.Parameters.AddWithValue("OBSERVACAO_ALUNO", envio.ObsAluno);
                        cmd.Parameters.AddWithValue("DATA_CORRECAO", envio.DataEnvio.ToShortDateString());
                        cmd.Parameters.AddWithValue("NOTA", envio.nota);
                        cmd.Parameters.AddWithValue("OBSERVACAO_PROFESSOR", envio.ObsProfessor);
                        cmd.Parameters.AddWithValue("[Código]", envio.Id);
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

        public List<Envio> GetAll()
        {
            List<Envio> result = new List<Envio>();

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
                                    var envio = new Envio
                                    {
                                        cronograma = new CronogramaDAL().GetById(reader.GetInt32(0)),
                                        aluno = reader[1] == DBNull.Value ? null : new AlunoDAL().GetByMatricula(reader.GetString(1)),
                                        Id = reader[2] == DBNull.Value ? 0 : reader.GetInt32(2),
                                        DataEnvio = reader[3] == DBNull.Value ? DateTime.MinValue : reader.GetDateTime(3),
                                        DataCorrecao = reader[4] == DBNull.Value ? DateTime.MinValue : reader.GetDateTime(4),
                                        ObsAluno = reader[5] == DBNull.Value ? String.Empty : reader.GetString(5),
                                        ObsProfessor = reader[6] == DBNull.Value ? String.Empty : reader.GetString(6),
                                        nota = reader[7] == DBNull.Value ? -1 : reader.GetInt32(7)
                                    };
                                    result.Add(envio);
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

        public Envio GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Envio envio)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_INSERT_ALUNO, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_CRONOGRAMA", envio.cronograma.Id);
                        cmd.Parameters.AddWithValue("MATRICULA", envio.aluno.Matricula);
                        cmd.Parameters.AddWithValue("DATA_ENVIO", envio.DataEnvio.ToShortDateString());
                        cmd.Parameters.AddWithValue("OBSERVACAO_ALUNO", envio.ObsAluno);
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
    }
}
