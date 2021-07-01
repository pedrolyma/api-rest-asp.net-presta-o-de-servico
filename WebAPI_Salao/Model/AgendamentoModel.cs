using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class AgendamentoModel
    {
        public long IdAgendamento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraAgendamento { get; set; }
        public decimal ValorServico { get; set; }
        public StatusAgendamento statusAgendamento { get; set; }
        public int id_Empresa { get; set; }
        public long id_Cliente { get; set; }
        public long id_Servico { get; set; }
        public long id_Horario { get; set; }
        public long id_Colaborador { get; set; }
    }
}
