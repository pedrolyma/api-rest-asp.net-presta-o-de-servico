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
    public class DaoHorario
    {
        public List<HorarioModel> GetHorarios()
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                List<HorarioModel> listaHorario = new List<HorarioModel>();
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_ListaHorario";
                comando.ExecuteNonQuery();
                DbDataReader reader = Conexao.GetDataReader(comando);
                HorarioModel objHorario;
                while (reader.Read())
                {
                    objHorario = new HorarioModel();
                    objHorario.IdHorario = Convert.ToInt32(reader["IdHorario"]);
                    objHorario.DataHorario = Convert.ToDateTime(reader["DataHorario"]);
                    objHorario.HoraHorario = Convert.ToDateTime(reader["HoraHorario"]);
                    objHorario.StatusHorario = reader["StatusHorario"].ToString();
                    objHorario.id_Empresa = Convert.ToInt32(reader["id_Empresa"]);
                    objHorario.id_Servico = Convert.ToInt32(reader["id_Servico"]);
                    objHorario.id_Colaborador = Convert.ToInt32(reader["id_Colaborador"]);
                    listaHorario.Add(objHorario);
                }
                return listaHorario;
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

        public async void InserirHorario(HorarioModel objHorario)
        {
            DbConnection conexao = Conexao.GetConexao();
            try
            {
                DbCommand comando = Conexao.GetComando(conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "InsertHorario";
                comando.Parameters.Add(new SqlParameter("@DataHorario", objHorario.DataHorario));
                comando.Parameters.Add(new SqlParameter("@HoraHorario", objHorario.HoraHorario));
                comando.Parameters.Add(new SqlParameter("@StatusHorario", objHorario.StatusHorario));
                comando.Parameters.Add(new SqlParameter("@id_Empresa", objHorario.id_Empresa));
                comando.Parameters.Add(new SqlParameter("@id_Servico", objHorario.id_Servico));
                comando.Parameters.Add(new SqlParameter("@id_Colaborador", objHorario.id_Colaborador));
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
