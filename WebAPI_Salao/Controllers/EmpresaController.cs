using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;
using WebAPI_Salao.Repositorio;

namespace WebAPI_Salao.Controllers
{
    [Route("api/v1/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaRepository empresaRepository;
        public EmpresaController()
        {
            empresaRepository = new EmpresaRepository();
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] EmpresaModel objEmpresa)
        {
            try
            {
                empresaRepository.Inserir(objEmpresa);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<List<EmpresaModel>> Get()
        {
            try
            {
                return empresaRepository.GetEmpresas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idEmpresa}")]
        public async Task<EmpresaModel> Get(long idEmpresa)
        {
            try
            {
                return empresaRepository.BuscaPorId(idEmpresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void Put([FromBody] EmpresaModel empresaModel)
        {
            try
            {
                empresaRepository.Atualizar(empresaModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void Delete(int idEmpresa)
        {
             empresaRepository.Excluir(idEmpresa);
        }
    }
}
