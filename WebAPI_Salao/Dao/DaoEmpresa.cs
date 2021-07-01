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
    public class DaoEmpresa
    {
        public List<EmpresaModel> GetEmpresas()
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<EmpresaModel> listaEmpresa = new List<EmpresaModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaEmpresa";
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                EmpresaModel objEmpresa;
                while (reader.Read())
                {
                    objEmpresa = new EmpresaModel();
                    objEmpresa.IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]);
                    objEmpresa.RazaoSocial = reader["RazaoSocial"].ToString();
                    objEmpresa.NomeFantasia = reader["NomeFantasia"].ToString();
                    objEmpresa.Cep = reader["Cep"].ToString();
                    objEmpresa.Logradouro = reader["Logradouro"].ToString();
                    objEmpresa.Bairro = reader["Bairro"].ToString();
                    objEmpresa.Cidade = reader["Cidade"].ToString();
                    objEmpresa.Estado = reader["Estado"].ToString();
                    objEmpresa.Telefone = reader["Telefone"].ToString();
                    objEmpresa.SenhaEmpresa = reader["SenhaEmpresa"].ToString();
                    objEmpresa.LoginEmpresa = reader["LoginEmpresa"].ToString();
                    objEmpresa.LogoEmpresa = reader["LogoEmpresa"].ToString();
                    objEmpresa.EmailEmpresa = reader["EmailEmpresa"].ToString();
                    listaEmpresa.Add(objEmpresa);
                }
                return listaEmpresa;
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

        public void InserirEmpresa(EmpresaModel objEmpresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertEmpresa";
                comando.Parameters.Add(new SqlParameter("@RazaoSocial", objEmpresa.RazaoSocial));
                comando.Parameters.Add(new SqlParameter("@NomeFantasia", objEmpresa.NomeFantasia));
                comando.Parameters.Add(new SqlParameter("@Cep", objEmpresa.Cep));
                comando.Parameters.Add(new SqlParameter("@Logradouro", objEmpresa.Logradouro));
                comando.Parameters.Add(new SqlParameter("@Bairro", objEmpresa.Bairro));
                comando.Parameters.Add(new SqlParameter("@Cidade", objEmpresa.Cidade));
                comando.Parameters.Add(new SqlParameter("@Estado", objEmpresa.Estado));
                comando.Parameters.Add(new SqlParameter("@LoginEmpresa", objEmpresa.LoginEmpresa));
                comando.Parameters.Add(new SqlParameter("@SenhaEmpresa", objEmpresa.SenhaEmpresa));
                comando.Parameters.Add(new SqlParameter("@LogoEmpresa", objEmpresa.LogoEmpresa));
                comando.Parameters.Add(new SqlParameter("@EmailEmpresa", objEmpresa.EmailEmpresa));
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

        public void AtualizarEmpresa(EmpresaModel objEmpresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateEmpresa";
                comando.Parameters.Add(new SqlParameter("@RazaoSocial", objEmpresa.RazaoSocial));
                comando.Parameters.Add(new SqlParameter("@NomeFantasia", objEmpresa.NomeFantasia));
                comando.Parameters.Add(new SqlParameter("@Cep", objEmpresa.Cep));
                comando.Parameters.Add(new SqlParameter("@Logradouro", objEmpresa.Logradouro));
                comando.Parameters.Add(new SqlParameter("@Bairro", objEmpresa.Bairro));
                comando.Parameters.Add(new SqlParameter("@Cidade", objEmpresa.Cidade));
                comando.Parameters.Add(new SqlParameter("@Estado", objEmpresa.Estado));
                comando.Parameters.Add(new SqlParameter("@LoginEmpresa", objEmpresa.LoginEmpresa));
                comando.Parameters.Add(new SqlParameter("@SenhaEmpresa", objEmpresa.SenhaEmpresa));
                comando.Parameters.Add(new SqlParameter("@LogoEmpresa", objEmpresa.LogoEmpresa));
                comando.Parameters.Add(new SqlParameter("@EmailEmpresa", objEmpresa.EmailEmpresa));
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

        public EmpresaModel GetEmpresaPorId(long idEmpresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_EmpresaPorId";
                comando.Parameters.Add(new SqlParameter("@IdEmpresa", idEmpresa));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                EmpresaModel objEmpresa = new EmpresaModel();
                while (reader.Read())
                {
                    objEmpresa = new EmpresaModel();
                    objEmpresa.IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]);
                    objEmpresa.RazaoSocial = reader["RazaoSocial"].ToString();
                    objEmpresa.NomeFantasia = reader["NomeFantasia"].ToString();
                    objEmpresa.Cep = reader["Cep"].ToString();
                    objEmpresa.Logradouro = reader["Logradouro"].ToString();
                    objEmpresa.Bairro = reader["Bairro"].ToString();
                    objEmpresa.Cidade = reader["Cidade"].ToString();
                    objEmpresa.Estado = reader["Estado"].ToString();
                    objEmpresa.Telefone = reader["Telefone"].ToString();
                    objEmpresa.SenhaEmpresa = reader["SenhaEmpresa"].ToString();
                    objEmpresa.LoginEmpresa = reader["LoginEmpresa"].ToString();
                    objEmpresa.LogoEmpresa = reader["LogoEmpresa"].ToString();
                    objEmpresa.EmailEmpresa = reader["EmailEmpresa"].ToString();
                }
                return objEmpresa;
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

        public void ExcluirEmpresa(long idEmpresa)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteEmpresa";
                comando.Parameters.Add(new SqlParameter("@IdEmpresa", idEmpresa));
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
