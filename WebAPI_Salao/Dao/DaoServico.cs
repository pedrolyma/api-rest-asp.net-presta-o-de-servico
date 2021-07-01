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
    public class DaoServico
    {
        public List<ServicoModel> GetServicos()
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<ServicoModel> listaServico = new List<ServicoModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaServico";
                comando.Parameters.Add(new SqlParameter("@id_Empresa", 1));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ServicoModel objServico;
                while (reader.Read())
                {
                    objServico = new ServicoModel();
                    objServico.IdServico = Convert.ToInt32(reader["IdServico"]);
                    objServico.DescricaoServico = reader["DescricaoServico"].ToString();
                    objServico.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
                    objServico.TempoServico = reader["TempoServico"].ToString();
                    objServico.MaterialServico = reader["MaterialServico"].ToString();
                    objServico.Cuidados = reader["Cuidados"].ToString();
                    objServico.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    listaServico.Add(objServico);
                }
                return listaServico;
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

        public async Task  InserirServico(ServicoModel objServico)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertServico";
                comando.Parameters.Add(new SqlParameter("@DescricaoServico", objServico.DescricaoServico));
                comando.Parameters.Add(new SqlParameter("@ValorServico", objServico.ValorServico));
                comando.Parameters.Add(new SqlParameter("@TempoServico", objServico.TempoServico));
                comando.Parameters.Add(new SqlParameter("@MaterialServico", objServico.MaterialServico));
                comando.Parameters.Add(new SqlParameter("@Cuidados", objServico.Cuidados));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objServico.id_Empresa));
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

        public void AtualizarServico(ServicoModel objServico)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateServico";
                comando.Parameters.Add(new SqlParameter("@IdServico", objServico.IdServico));
                //RepassaDados(objServico);
                comando.Parameters.Add(new SqlParameter("@DescricaoServico", objServico.DescricaoServico));
                comando.Parameters.Add(new SqlParameter("@ValorServico", objServico.ValorServico));
                comando.Parameters.Add(new SqlParameter("@TempoServico", objServico.TempoServico));
                comando.Parameters.Add(new SqlParameter("@MaterialServico", objServico.MaterialServico));
                comando.Parameters.Add(new SqlParameter("@Cuidados", objServico.Cuidados));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objServico.id_Empresa));
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

        public ServicoModel GetServicoPorId(long idServico, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ServicoPorId";
                comando.Parameters.Add(new SqlParameter("@IdServico", idServico));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ServicoModel objServico = new ServicoModel();
                while (reader.Read())
                {
                    objServico = new ServicoModel();
                    objServico.IdServico = Convert.ToInt32(reader["IdServico"]);
                    objServico.DescricaoServico = reader["DescricaoServico"].ToString();
                    objServico.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
                    objServico.TempoServico = reader["TempoServico"].ToString();
                    objServico.MaterialServico = reader["MaterialServico"].ToString();
                    objServico.Cuidados = reader["Cuidados"].ToString();
                    objServico.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                }
                return objServico;
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

        public void ExcluirServico(long idServico, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteServico";
                comando.Parameters.Add(new SqlParameter("@IdUsuario", idServico));
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

        public async Task<ServicoModel> ServicoExiste(string descricaoServico)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandText = "select DescricaoServico from TB_Servico like DescricaoServico = DescricaoServico";
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ServicoModel objServico = new ServicoModel();
                if (reader.Read())
                {
                    objServico = new ServicoModel();
                    objServico.IdServico = Convert.ToInt32(reader["IdServico"]);
                    objServico.DescricaoServico = reader["DescricaoServico"].ToString();
                    objServico.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
                    objServico.TempoServico = reader["TempoServico"].ToString();
                    objServico.MaterialServico = reader["MaterialServico"].ToString();
                    objServico.Cuidados = reader["Cuidados"].ToString();
                    objServico.id_Empresa = Convert.ToInt32(reader["id_empresa"]);
                }
                return objServico;
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
        //public ServicoModel RepassaDados(ServicoModel objServico)
        //{
        //    DbCommand comando = Conexao.GetComando(conexao);
        //    comando.Parameters.Add(new SqlParameter("@DescricaoServico", objServico.DescricaoServico));
        //    comando.Parameters.Add(new SqlParameter("@TempoServico", objServico.TempoServico));
        //    comando.Parameters.Add(new SqlParameter("@MaterialServico", objServico.MaterialServico));
        //    comando.Parameters.Add(new SqlParameter("@Cuidados", objServico.Cuidados));
        //    comando.Parameters.Add(new SqlParameter("@id_empresa", objServico.id_empresa));
        //}
    }
}
