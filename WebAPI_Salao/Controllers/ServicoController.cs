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
    [Route("api/v1/servico")]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository servicoRepository;

        public ServicoController()
        {
            servicoRepository = new ServicoRepository();
        }

        [HttpGet]
        public List<ServicoModel> GetServico()
        {
            try
            {
                return servicoRepository.GetServicos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<bool> Post([FromBody] ServicoModel servicoModel)
        {
            try
            {
                await servicoRepository.Inserir(servicoModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idServico}")]
        public async Task<ServicoModel> Get(long idServico, long id_Empresa)
        {
            try
            {
                return await servicoRepository.BuscaPorId(idServico, id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async void Put([FromBody] ServicoModel servicoModel)
        {
            try
            {
                servicoRepository.Atualizar(servicoModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async void Delete(long idServico, long id_Empresa)
        {
            servicoRepository.Excluir(idServico, id_Empresa);
        }
    }
}
