using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Dao
{
    public class DaoColaborador
    {
        public async Task<List<ColaboradorModel>> GetColaborador()
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<ColaboradorModel> listaColaborador = new List<ColaboradorModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaColaborador";
                comando.Parameters.Add(new SqlParameter("@id_Empresa", 1));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ColaboradorModel objColaborador;
                while (reader.Read())
                {
                    objColaborador = new ColaboradorModel();
                    objColaborador.IdColaborador = Convert.ToInt32(reader["IdColaborador"]);
                    objColaborador.NomeColaborador = reader["NomeColaborador"].ToString();
                    objColaborador.WhatsAppColaborador = reader["WhatsAppColaborador"].ToString();
                    objColaborador.TikTokColaborador = reader["TikTokColaborador"].ToString();
                    objColaborador.TwitterColaborador = reader["TwitterColaborador"].ToString();
                    objColaborador.InstagranColaborador = reader["InstagranColaborador"].ToString();
                    objColaborador.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    listaColaborador.Add(objColaborador);
                }
                return listaColaborador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<ColaboradorModel> ColaboradorPorId(long idColaborador, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ColaboradorPorId";
                comando.Parameters.Add(new SqlParameter("@IdColaborador", idColaborador));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ColaboradorModel objColaborador = new ColaboradorModel();
                while (reader.Read())
                {
                    objColaborador = new ColaboradorModel();
                    objColaborador.IdColaborador = Convert.ToInt32(reader["IdColaborador"]);
                    objColaborador.NomeColaborador = reader["NomeColaborador"].ToString();
                    objColaborador.WhatsAppColaborador = reader["WhatsAppColaborador"].ToString();
                    objColaborador.TikTokColaborador = reader["TikTokColaborador"].ToString();
                    objColaborador.TwitterColaborador = reader["TwitterColaborador"].ToString();
                    objColaborador.InstagranColaborador = reader["InstagranColaborador"].ToString();
                    objColaborador.FotoColaborador = reader["FotoColaborador"].ToString();
                    objColaborador.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                }
                return objColaborador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task InserirColaborador(ColaboradorModel objColaborador)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertColaborador";
                comando.Parameters.Add(new SqlParameter("@NomeColaborador", objColaborador.NomeColaborador));
                comando.Parameters.Add(new SqlParameter("@WhatsAppColaborador", objColaborador.WhatsAppColaborador));
                comando.Parameters.Add(new SqlParameter("@TikTokColaborador", objColaborador.TikTokColaborador));
                comando.Parameters.Add(new SqlParameter("@TwitterColaborador", objColaborador.TwitterColaborador));
                comando.Parameters.Add(new SqlParameter("@InstagranColaborador", objColaborador.InstagranColaborador));
                comando.Parameters.Add(new SqlParameter("@FotoColaborador", objColaborador.FotoColaborador));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objColaborador.id_Empresa));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async void AtualizarColaborador(ColaboradorModel objColaborador)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateColaborador";
                comando.Parameters.Add(new SqlParameter("@IdColaborador", objColaborador.IdColaborador));
                comando.Parameters.Add(new SqlParameter("@NomeColaborador", objColaborador.NomeColaborador));
                comando.Parameters.Add(new SqlParameter("@WhatsAppColaborador", objColaborador.WhatsAppColaborador));
                comando.Parameters.Add(new SqlParameter("@TikTokColaborador", objColaborador.TikTokColaborador));
                comando.Parameters.Add(new SqlParameter("@TwitterColaborador", objColaborador.TwitterColaborador));
                comando.Parameters.Add(new SqlParameter("@InstagranColaborador", objColaborador.InstagranColaborador));
                comando.Parameters.Add(new SqlParameter("@FotoColaborador", objColaborador.FotoColaborador));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objColaborador.id_Empresa));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async Task<ColaboradorModel> ColaboradorExiste(string nomeColaborador)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandText = "select NomeColaborador from TB_Colaborador like NomeColaborador = nomeColaborador";
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ColaboradorModel objColaborador = new ColaboradorModel();
                if (reader.Read())
                {
                    objColaborador = new ColaboradorModel();
                    objColaborador.IdColaborador = Convert.ToInt32(reader["IdColaborador"]);
                    objColaborador.NomeColaborador = reader["NomeColaborador"].ToString();
                    objColaborador.WhatsAppColaborador = reader["WhatsAppColaborador"].ToString();
                    objColaborador.TikTokColaborador = reader["TikTokColaborador"].ToString();
                    objColaborador.TwitterColaborador = reader["TwitterColaborador"].ToString();
                    objColaborador.InstagranColaborador = reader["InstagranColaborador"].ToString();
                    objColaborador.FotoColaborador = reader["FotoColaborador"].ToString();
                    objColaborador.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                }
                return objColaborador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }

        public async void ExcluirColaborador(long IdColaborador, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteColaborador";
                comando.Parameters.Add(new SqlParameter("@IdColaborador", IdColaborador));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Conexao.FechaConecao(conexao);
            }
        }
    }
}
