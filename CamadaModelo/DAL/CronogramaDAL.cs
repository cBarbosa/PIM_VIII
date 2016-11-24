using System;
using System.Collections.Generic;
using PIM_VIII.VO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Linq;

namespace PIM_VIII.Model
{
    public class CronogramaDAL : IConnection<PIM_VIII.VO.Cronograma>
    {
        const string _TABLE = "tbl_cronograma";
        const string _SELECT_ALL = @"SELECT tbl_cronograma.ID_CRONOGRAMA,
                                tbl_atividades.ID_ATIVIDADE, tbl_atividades.ATIVIDADE,
                                tbl_disciplinas.ID_DISCIPLINA, tbl_disciplinas.DISCIPLINA,
                                tbl_curso.ID_CURSO, tbl_curso.CURSO,
                                tbl_cronograma.[DATA INICIAL DE ENTREGA], tbl_cronograma.[DATA FINAL   DE ENTREGA]
                                FROM tbl_curso
                                INNER JOIN (tbl_disciplinas INNER JOIN (tbl_cronograma INNER JOIN tbl_atividades ON tbl_cronograma.ID_ATIVIDADE = tbl_atividades.ID_ATIVIDADE) ON tbl_disciplinas.ID_DISCIPLINA = tbl_cronograma.ID_DISCIPLINA) ON tbl_curso.ID_CURSO = tbl_disciplinas.ID_CURSO
                                ORDER BY [DATA INICIAL DE ENTREGA] ASC";
        const string _SELECT_ID = @"SELECT tbl_cronograma.ID_CRONOGRAMA,
                                tbl_atividades.ID_ATIVIDADE, tbl_atividades.ATIVIDADE,
                                tbl_disciplinas.ID_DISCIPLINA, tbl_disciplinas.DISCIPLINA,
                                tbl_curso.ID_CURSO, tbl_curso.CURSO,
                                tbl_cronograma.[DATA INICIAL DE ENTREGA], tbl_cronograma.[DATA FINAL   DE ENTREGA]
                                FROM tbl_curso
                                INNER JOIN (tbl_disciplinas INNER JOIN (tbl_cronograma INNER JOIN tbl_atividades ON tbl_cronograma.ID_ATIVIDADE = tbl_atividades.ID_ATIVIDADE) ON tbl_disciplinas.ID_DISCIPLINA = tbl_cronograma.ID_DISCIPLINA) ON tbl_curso.ID_CURSO = tbl_disciplinas.ID_CURSO
                                WHERE ID_CRONOGRAMA = ?";
        const string _UPDATE_ID = @"UPDATE tbl_cronograma SET ID_ATIVIDADE = ?, ID_DISCIPLINA = ?, [DATA INICIAL DE ENTREGA] = ?, [DATA FINAL   DE ENTREGA] = ?
                                    WHERE ID_CRONOGRAMA = ?";
        const string _INSERT = @"INSERT INTO tbl_cronograma (ID_ATIVIDADE, ID_DISCIPLINA, [DATA INICIAL DE ENTREGA], [DATA FINAL   DE ENTREGA])
                                    VALUES(?,?,?,?)";

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

        public void Atualiza(Cronograma cronograma)
        {
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_UPDATE_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_ATIVIDADE", cronograma.atividade.Id);
                        cmd.Parameters.AddWithValue("ID_DISCIPLINA", cronograma.disciplina.Id);
                        cmd.Parameters.AddWithValue("[DATA INICIAL DE ENTREGA]", cronograma.DataInicio);
                        cmd.Parameters.AddWithValue("[DATA FINAL   DE ENTREGA]", cronograma.DataFim);
                        cmd.Parameters.AddWithValue("ID_CRONOGRAMA", cronograma.Id);
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

        public List<Cronograma> GetAll()
        {
            List<Cronograma> result = new List<Cronograma>();

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
                                    var crono = new Cronograma
                                    {
                                        Id = reader.GetInt32(0),
                                        atividade = new Atividade()
                                        {
                                            Id = reader.GetInt32(1),
                                            Nome = reader.GetString(2)
                                        },
                                        disciplina = new Disciplina()
                                        {
                                            Id = reader.GetInt32(3),
                                            Nome = reader.GetString(4),
                                            curso = new Curso()
                                            {
                                                 Id = reader.GetInt32(5),
                                                 Nome = reader.GetString(6)
                                            }
                                        },
                                        DataInicio = reader.GetDateTime(7),
                                        DataFim = reader.GetDateTime(8)
                                    };
                                    result.Add(crono);
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

        public Cronograma GetById(int id)
        {
            Cronograma result = new Cronograma();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_CRONOGRAMA", id);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Cronograma
                                {
                                    Id = reader.GetInt32(0),
                                    atividade = new Atividade()
                                    {
                                        Id = reader.GetInt32(1),
                                        Nome = reader.GetString(2)
                                    },
                                    disciplina = new Disciplina()
                                    {
                                        Id = reader.GetInt32(3),
                                        Nome = reader.GetString(4),
                                        curso = new Curso()
                                        {
                                            Id = reader.GetInt32(5),
                                            Nome = reader.GetString(6)
                                        }
                                    },
                                    DataInicio = reader.GetDateTime(7),
                                    DataFim = reader.GetDateTime(8)
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

        public void Insere(Cronograma cronograma)
        {
            using (var conexao = GetDBConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID_ATIVIDADE", cronograma.atividade.Id);
                    cmd.Parameters.AddWithValue("ID_DISCIPLINA", cronograma.disciplina.Id);
                    cmd.Parameters.AddWithValue("[DATA INICIAL DE ENTREGA]", cronograma.DataInicio);
                    cmd.Parameters.AddWithValue("[DATA FINAL   DE ENTREGA]", cronograma.DataFim);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Cronograma> GetAllAtividadesByIdCurso(int idCurso)
        {
            try
            {
                return GetAll().Where(x => x.disciplina.curso.Id == idCurso).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
