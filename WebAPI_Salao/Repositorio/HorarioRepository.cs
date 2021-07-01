using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class HorarioRepository
    {
        private readonly DaoHorario daoHorario;

        public HorarioRepository()
        {
            daoHorario = new DaoHorario();
        }

        public async Task<List<HorarioModel>> GetHorarios()
        {
            return daoHorario.GetHorarios();
        }

        public async Task<bool> InserirHorario(HorarioModel horarioModel)
        {
            daoHorario.InserirHorario(horarioModel);
            return true;
        }
    }
}
