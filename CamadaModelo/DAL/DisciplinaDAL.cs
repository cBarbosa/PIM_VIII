using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_VII.VO;

namespace PIM_VIII.Model
{
    public class DisciplinaDAL : IConnection<PIM_VII.VO.Disciplina>
    {
        const string _TABLE = "tbl_disciplinas";
        const string _SELECT_ALL = @"SELECT ID_DISCIPLINA, DISCIPLINA, tbl_curso.ID_CURSO, tbl_curso.CURSO
                            FROM tbl_disciplinas INNER JOIN tbl_curso ON tbl_disciplinas.ID_CURSO = tbl_curso.ID_CURSO ";
        const string _SELECT_MAX = "SELECT MAX(ID_DISCIPLINA) FROM tbl_disciplinas";
        const string _INSERT = "INSERT INTO tbl_disciplinas (ID_DISCIPLINA, DISCIPLINA, ID_CURSO, ID_ATIVIDADE) VALUES (?,?,?,?)";

        const string _SELECT_ID = @"SELECT ID_DISCIPLINA, DISCIPLINA, ID_CURSO
                            FROM tbl_disciplinas WHERE ID_DISCIPLINA = ?";

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

        public static int GetMax()
        {
            int result = 0;
            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_MAX, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        conexao.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception) { return -1; }

            return ++result;
        }

        public static int Insere(string Disciplina, int idCurso, int idAtividade)
        {
            int idMax = GetMax();
            using (var conexao = GetDBConnection())
            {
                using (OleDbCommand cmd = new OleDbCommand(_INSERT, conexao))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID_DISCIPLINA", idMax);
                    cmd.Parameters.AddWithValue("DISCIPLINA", Disciplina);
                    cmd.Parameters.AddWithValue("ID_CURSO", idCurso);
                    cmd.Parameters.AddWithValue("ID_ATIVIDADE", idAtividade);
                    conexao.Open();
                    cmd.ExecuteNonQuery();

                    return idMax;
                }   
            }
        }

        public List<Disciplina> GetAll()
        {
            List<Disciplina> result = new List<Disciplina>();

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
                                    var _disciplina = new Disciplina()
                                    {
                                        Id = reader.GetInt32(0),
                                        Nome = reader.GetString(1),
                                        curso = new Curso()
                                        {
                                            Id = reader.GetInt32(2),
                                            Nome = reader.GetString(3)
                                        }
                                    };
                                    result.Add(_disciplina);
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

        public Disciplina GetById(int id)
        {
            Disciplina result = new Disciplina();

            try
            {
                using (var conexao = GetDBConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand(_SELECT_ID, conexao))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("ID_DISCIPLINA", id);
                        conexao.Open();

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Disciplina
                                {
                                    Id = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    curso = reader[2] == DBNull.Value ? null : new CursoDAL().GetById(reader.GetInt32(2))
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

        public void Insere(Disciplina obj)
        {
            throw new NotImplementedException();
        }

        public void Atualiza(Disciplina obj)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }
    }
}
