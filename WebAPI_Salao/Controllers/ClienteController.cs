using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Model;
using WebAPI_Salao.Repositorio;

namespace WebAPI_Salao.Controllers
{
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository clienteRepository;

        public ClienteController()
        {
            clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public async Task<List<ClienteModel>> Get(long id_Empresa=1)
        {
            try
            {
                return await clienteRepository.GetClientes(id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idCliente}")]
        public async Task<ClienteModel> Get(long idCliente, long id_Empresa)
        {
            try
            {
                return await clienteRepository.BuscaPorId(idCliente, id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] ClienteModel clienteModel)
        {
            try
            {
                await clienteRepository.Inserir(clienteModel);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<bool> Put(ClienteModel clienteModel)
        {
            try
            {
                await clienteRepository.Atualizar(clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idCliente}")]
        public async void Delete(long idCliente, long id_Empresa)
        {
            try
            {
                clienteRepository.Excluir(idCliente, id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


