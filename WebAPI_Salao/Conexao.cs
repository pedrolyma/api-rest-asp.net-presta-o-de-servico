using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao
{
    public class Conexao
    {
  //      private IConfiguration _configuration;
        //public Conexao(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    string conec = _configuration.GetSection("ConnectionStringId").GetSection("DefaultConnection").Value;
        //}
//        string connection = _con  GetConnectionString().ToString .GetSection("MySettings").GetSection("Parameters").GetSection("IsProduction").Value); // here

        public static DbConnection GetConexao()
        {
            //private IConfiguration _configuration;
            //public GetConexao(IConfiguration configuration)
            //{
            //    _configuration = configuration;
            //    string conec = _configuration.GetSection("ConnectionStringId").GetSection("DefaultConnection").Value;
            //}
            //           string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string connection = "Data Source=PEDROLIMA\\SQLEXPRESS;Initial Catalog=DBSalaoVip;User ID=peter;Password=505035";
            try
            {
                DbConnection conexao = new SqlConnection(connection);
                conexao.Open();
                return conexao;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DbCommand GetComando(DbConnection conecao)
        {
            DbCommand comando = conecao.CreateCommand();
            return comando;
        }

        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }

        public static void FechaConecao(DbConnection conecao)
        {
            conecao.Close();
        }
    }
}
