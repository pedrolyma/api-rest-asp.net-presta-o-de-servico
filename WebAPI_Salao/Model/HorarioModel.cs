using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class HorarioModel
    {
        public long IdHorario;
        public DateTime DataHorario;
        public DateTime HoraHorario;
        public string StatusHorario;
        public long id_Servico;
        public long id_Empresa;
        public long id_Colaborador;
    }
}
