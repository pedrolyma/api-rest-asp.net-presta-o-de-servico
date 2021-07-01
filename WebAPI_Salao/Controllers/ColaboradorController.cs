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
    [Route("api/v1/colaborador")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorRepository colaboradorRepository;

        public ColaboradorController()
        {
            colaboradorRepository = new ColaboradorRepository();
        }

        [HttpGet]
        public async Task<List<ColaboradorModel>> Get()
        {
            try
            {
                return await colaboradorRepository.GetColaborador();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idColaborador}")]
        public async Task<ColaboradorModel> Get(long idColaborador, long id_Empresa)
        {
            try
            {
                return await colaboradorRepository.BuscaPorId(idColaborador, id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ColaboradorModel colaboradorModel)
        {
            try
            {
                await colaboradorRepository.Inserir(colaboradorModel);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return UnprocessableEntity("Ja Existe um Colaborador com Este Nome Cadastrado");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ColaboradorModel colaboradorModel)
        {
            try
            {
                await colaboradorRepository.Atualizar(colaboradorModel);
                return Ok();
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long IdColaborador, long id_Empresa)
        {
            try
            {
                await colaboradorRepository.Excluir(IdColaborador, id_Empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public Task<List<ColaboradorModel>> Obter(string nomeColaborador)
        //{
        //    return Task.FromResult(ColaboradorModel.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        //}
    }
}
