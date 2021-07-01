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
    [Route("api/v1/agendamento")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoRepository agendamentoRepository;

        public AgendamentoController()
        {
            agendamentoRepository = new AgendamentoRepository();
        }

        [HttpGet]
        public async Task<List<AgendamentoModel>> Get(long id_Empresa)
        {
            try
            {
                return await agendamentoRepository.ListaAgendamento(id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idAgendamento}")]
        public async Task<AgendamentoModel> Get(long idAgendamento, long id_Empresa)
        {
            try
            {
                return await agendamentoRepository.GetAgendamentoPorId(idAgendamento, id_Empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<bool> Post(AgendamentoModel agendaModel)
        {
            try
            {
                await agendamentoRepository.Inserir(agendaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async void Delete(long idAgenda, long id_Empresa)
        {
            agendamentoRepository.Excluir(idAgenda, id_Empresa);
        }
    }
}
