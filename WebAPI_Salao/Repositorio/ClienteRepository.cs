using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class ClienteRepository
    {
        private readonly DaoCliente daoCliente;

        public ClienteRepository()
        {
            daoCliente = new DaoCliente();
        }

        public async Task<List<ClienteModel>> GetClientes(long id_Empresa)
        {
            return daoCliente.GetClientes(id_Empresa);
        }

        public async Task<bool> Inserir(ClienteModel objCliente)
        {
            daoCliente.InserirCliente(objCliente);
            return true;
        }

        public async Task<bool> Atualizar(ClienteModel objCliente)
        {
            daoCliente.AtualizarCliente(objCliente);
            return true;
        }

        public async Task<ClienteModel> BuscaPorId(long idCliente, long id_Empresa)
        {
            return daoCliente.GetClientePorId(idCliente, id_Empresa);
        }

        public async void Excluir(long idCliente, long id_Empresa)
        {
            daoCliente.ExcluirCliente(idCliente, id_Empresa);
        }
    }
}
