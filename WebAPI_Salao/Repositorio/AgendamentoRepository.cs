using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class AgendamentoRepository
    {
        private readonly DaoAgendamento daoAgenda;

        public AgendamentoRepository()
        {
            daoAgenda = new DaoAgendamento();
        }

        public async Task<List<AgendamentoModel>> ListaAgendamento(long id_Empresa)
        {
            return await daoAgenda.ListaAgendamento(id_Empresa);
        }

        public async Task<bool> Inserir(AgendamentoModel agendaModel)
        {
            daoAgenda.InserirAgendamento(agendaModel);
            return true;
        }

        public async Task<bool> Atualizar(AgendamentoModel agendaModel)
        {
            daoAgenda.AtualizarAgendamento(agendaModel);
            return true;
        }

        public async void Excluir(long idAgendamento, long id_Empresa)
        {
            daoAgenda.ExcluirAgendamento(idAgendamento, id_Empresa);
        }

        public async Task<AgendamentoModel> GetAgendamentoPorId(long idAgendamento, long id_Empresa)
        {
            return await daoAgenda.GetAgendamentoPorId(idAgendamento, id_Empresa);
        }
    }
}
