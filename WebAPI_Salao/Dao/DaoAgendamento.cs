using Microsoft.AspNetCore.Mvc;
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
    public class DaoAgendamento
    {
        public async Task<List<AgendamentoModel>> ListaAgendamento(long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<AgendamentoModel> listaAgendamento = new List<AgendamentoModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaAgendamento";
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                AgendamentoModel objAgendamento;
                while (reader.Read())
                {
                    objAgendamento = new AgendamentoModel();
                    objAgendamento.DataAgendamento = Convert.ToDateTime(reader["DataAgendamento"]);
                    objAgendamento.HoraAgendamento = Convert.ToDateTime(reader["HoraAgendamento"]);
                    objAgendamento.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
  //                  objAgendamento.statusAgendamento = reader["StatusAgendamento"];
                    objAgendamento.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    objAgendamento.id_Cliente = Convert.ToInt32(reader["id_Cliente"]);
                    objAgendamento.id_Servico = Convert.ToInt32(reader["id_Servico"]);
                    objAgendamento.id_Horario = Convert.ToInt32(reader["id_Horario"]);
                    objAgendamento.id_Colaborador = Convert.ToInt32(reader["id_Colaborador"]);
                    listaAgendamento.Add(objAgendamento);
                }
                return listaAgendamento;
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

        public async void InserirAgendamento([FromBody] AgendamentoModel objAgendamento)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertAgendamento";
                comando.Parameters.Add(new SqlParameter("@DataAgendamento", objAgendamento.DataAgendamento));
                comando.Parameters.Add(new SqlParameter("@HoraAgendamento", objAgendamento.HoraAgendamento));
                comando.Parameters.Add(new SqlParameter("@ValorServico", objAgendamento.ValorServico));
                comando.Parameters.Add(new SqlParameter("@StatusAgendamento", objAgendamento.statusAgendamento));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objAgendamento.id_Empresa));
                comando.Parameters.Add(new SqlParameter("@id_Cliente", objAgendamento.id_Cliente));
                comando.Parameters.Add(new SqlParameter("@id_Servico", objAgendamento.id_Servico));
                comando.Parameters.Add(new SqlParameter("@id_Horario", objAgendamento.id_Horario));
                comando.Parameters.Add(new SqlParameter("@id_Colaborador", objAgendamento.id_Colaborador));
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

        public async void AtualizarAgendamento([FromBody] AgendamentoModel objAgendamento)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateAgendamento";
                comando.Parameters.Add(new SqlParameter("@IdAgendamento", objAgendamento.IdAgendamento));
                comando.Parameters.Add(new SqlParameter("@DataAgenda", objAgendamento.DataAgendamento));
                comando.Parameters.Add(new SqlParameter("@HoraAgenda", objAgendamento.HoraAgendamento));
                comando.Parameters.Add(new SqlParameter("@ValorServico", objAgendamento.ValorServico));
                comando.Parameters.Add(new SqlParameter("@StatusAgenda", objAgendamento.statusAgendamento));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objAgendamento.id_Empresa));
                comando.Parameters.Add(new SqlParameter("@id_Cliente", objAgendamento.id_Cliente));
                comando.Parameters.Add(new SqlParameter("@id_Servico", objAgendamento.id_Servico));
                comando.Parameters.Add(new SqlParameter("@id_Horario", objAgendamento.id_Horario));
                comando.Parameters.Add(new SqlParameter("@id_Colaborador", objAgendamento.id_Colaborador));
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

        public async Task<AgendamentoModel> GetAgendamentoPorId(long IdAgendamento, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                AgendamentoModel objAgendamento = new AgendamentoModel();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_AgendamentoPorId";
                comando.Parameters.Add(new SqlParameter("@IdAgendamento", IdAgendamento));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                while (reader.Read())
                {
                    objAgendamento = new AgendamentoModel();
                    objAgendamento.DataAgendamento = Convert.ToDateTime(reader["DataAgendamento"]);
                    objAgendamento.HoraAgendamento = Convert.ToDateTime(reader["HoraAgendamento"]);
                    objAgendamento.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
 //                   objAgendamento.statusAgendamento = reader["StatusAgendamento"];
                    objAgendamento.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    objAgendamento.id_Cliente = Convert.ToInt32(reader["id_Cliente"]);
                    objAgendamento.id_Servico = Convert.ToInt32(reader["id_Servico"]);
                    objAgendamento.id_Horario = Convert.ToInt32(reader["id_Horario"]);
                    objAgendamento.id_Colaborador = Convert.ToInt32(reader["id_Colaborador"]);
                }
                return objAgendamento;
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

        public async void ExcluirAgendamento(long IdAgendamento, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteAgendamento";
                comando.Parameters.Add(new SqlParameter("@IdAgendamento", IdAgendamento));
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
