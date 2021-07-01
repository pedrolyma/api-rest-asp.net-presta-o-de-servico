using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Model;
using WebAPI_Salao.Repositorio;

namespace WebAPI_Salao.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public async Task<List<UsuarioModel>> Get()
        {
            try
            {
                return await usuarioRepository.GetUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UsuarioModel> Get(long idUsuario)
        {
            try
            {
                return usuarioRepository.BuscaPorId(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async void Post([FromBody] UsuarioModel objUsuario)
        {
            try
            {
                usuarioRepository.Inserir(objUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idUsuario}")]
        public async void Delete(long idUsuario)
        {
            try
            {
                usuarioRepository.Excluir(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async void Put([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                usuarioRepository.Atualizar(usuarioModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
