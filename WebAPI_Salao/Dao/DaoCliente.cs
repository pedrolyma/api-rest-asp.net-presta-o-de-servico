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
    public class DaoCliente
    {
        public List<ClienteModel> GetClientes(long id_Empresa=1)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<ClienteModel> listaCliente = new List<ClienteModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaCliente";
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ClienteModel objCliente;
                while (reader.Read())
                {
                    objCliente = new ClienteModel();
                    objCliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    objCliente.NomeCliente = reader["NomeCliente"].ToString();
                    objCliente.Logradouro = reader["Logradouro"].ToString();
                    objCliente.Telefone = reader["Telefone"].ToString();
                    objCliente.WhatsApp = reader["WhatsApp"].ToString();
                    objCliente.Twitter = reader["Twitter"].ToString();
                    objCliente.Instagran = reader["Instagran"].ToString();
                    objCliente.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    listaCliente.Add(objCliente);
                }
                return listaCliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void InserirCliente([FromBody] ClienteModel objCliente)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertCliente";
                comando.Parameters.Add(new SqlParameter("@NomeCliente", objCliente.NomeCliente));
                comando.Parameters.Add(new SqlParameter("@Logradouro", objCliente.Logradouro));
                comando.Parameters.Add(new SqlParameter("@Telefone", objCliente.Telefone));
                comando.Parameters.Add(new SqlParameter("@WhatsApp", objCliente.WhatsApp));
                comando.Parameters.Add(new SqlParameter("@Twitter", objCliente.Twitter));
                comando.Parameters.Add(new SqlParameter("@instagran", objCliente.Instagran));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objCliente.id_Empresa));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void AtualizarCliente([FromBody] ClienteModel objCliente)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateCliente";
                comando.Parameters.Add(new SqlParameter("@IdCliente", objCliente.IdCliente));
                comando.Parameters.Add(new SqlParameter("@NomeCliente", objCliente.NomeCliente));
                comando.Parameters.Add(new SqlParameter("@Logradouro", objCliente.Logradouro));
                comando.Parameters.Add(new SqlParameter("@Telefone", objCliente.Telefone));
                comando.Parameters.Add(new SqlParameter("@WhatsApp", objCliente.WhatsApp));
                comando.Parameters.Add(new SqlParameter("@Twitter", objCliente.Twitter));
                comando.Parameters.Add(new SqlParameter("@instagran", objCliente.Instagran));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objCliente.id_Empresa));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClienteModel GetClientePorId(long idCliente, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ClientePorId";
                comando.Parameters.Add(new SqlParameter("@IdCliente", idCliente));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", id_Empresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                ClienteModel objCliente = new ClienteModel();
                while (reader.Read())
                {
                    objCliente = new ClienteModel();
                    objCliente.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    objCliente.NomeCliente = reader["NomeCliente"].ToString();
                    objCliente.Logradouro = reader["Logradouro"].ToString();
                    objCliente.Telefone = reader["Telefone"].ToString();
                    objCliente.WhatsApp = reader["WhatsApp"].ToString();
                    objCliente.Twitter = reader["Twitter"].ToString();
                    objCliente.Instagran = reader["Instagran"].ToString();
                    objCliente.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                }
                return objCliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void ExcluirCliente(long idCliente, long id_Empresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteCliente";
                comando.Parameters.Add(new SqlParameter("@IdCliente", idCliente));
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
