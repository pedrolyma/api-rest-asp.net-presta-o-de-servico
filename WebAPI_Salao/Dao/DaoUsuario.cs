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
    public class DaoUsuario
    {
        public List<UsuarioModel> GetUsuarios()
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<UsuarioModel> listaUsuario = new List<UsuarioModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaUsuario";
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                UsuarioModel objUsuario;
                while (reader.Read())
                {
                    objUsuario = new UsuarioModel();
                    objUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    objUsuario.NomeUsuario = reader["NomeUsuario"].ToString();
                    objUsuario.EmailUsuario = reader["EmailUsuario"].ToString();
                    objUsuario.LoginUsuario = reader["LoginUsuario"].ToString();
                    objUsuario.SenhaUsuario = reader["SenhaUsuario"].ToString();
                    listaUsuario.Add(objUsuario);
                }
                return listaUsuario;
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

        public void InserirUsuario(UsuarioModel objUsuario)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_InsertUsuario";
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", objUsuario.NomeUsuario));
                comando.Parameters.Add(new SqlParameter("@EmailUsuario", objUsuario.EmailUsuario));
                comando.Parameters.Add(new SqlParameter("@LoginUsuario", objUsuario.LoginUsuario));
                comando.Parameters.Add(new SqlParameter("@SenhaUsuario", objUsuario.SenhaUsuario));
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

        public void AtualizarUsuario(UsuarioModel objUsuario)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UpdateUsuario";
                comando.Parameters.Add(new SqlParameter("@IdUsuario", objUsuario.IdUsuario));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", objUsuario.NomeUsuario));
                comando.Parameters.Add(new SqlParameter("@EmailUsuario", objUsuario.EmailUsuario));
                comando.Parameters.Add(new SqlParameter("@LoginUsuario", objUsuario.LoginUsuario));
                comando.Parameters.Add(new SqlParameter("@SenhaUsuario", objUsuario.SenhaUsuario));
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

        public UsuarioModel GetUsuarioPorId(long idUsuario)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_UsuarioPorId";
                comando.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                UsuarioModel objUsuario = new UsuarioModel();
                while (reader.Read())
                {
                    objUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    objUsuario.NomeUsuario = reader["NomeUsuario"].ToString();
                    objUsuario.EmailUsuario = reader["EmailUsuario"].ToString();
                    objUsuario.LoginUsuario = reader["LoginUsuario"].ToString();
                    objUsuario.SenhaUsuario = reader["SenhaUsuario"].ToString();
                }
                return objUsuario;
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

        public void ExcluirUsuario(long idUsuario)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_DeleteUsuario";
                comando.Parameters.Add(new SqlParameter("@IdUsuario", idUsuario));
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

