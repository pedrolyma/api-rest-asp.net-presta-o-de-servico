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
    [Route("api/v1/horario")]
    public class HorarioController
    {
        private readonly HorarioRepository horarioRepository;

        public HorarioController()
        {
            horarioRepository = new HorarioRepository();
        }

        [HttpGet]
        public async Task<List<HorarioModel>> Get()
        {
            try
            {
                return await horarioRepository.GetHorarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
