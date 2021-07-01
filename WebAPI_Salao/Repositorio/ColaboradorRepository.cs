using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Exceptions;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class ColaboradorRepository
    {
        private readonly DaoColaborador daoColaborador;

        public ColaboradorRepository()
        {
            daoColaborador = new DaoColaborador();
        }

        public async Task<List<ColaboradorModel>> GetColaborador()
        {
            return await daoColaborador.GetColaborador();
        }

        public async Task<bool> Atualizar(ColaboradorModel colaboradorModel)
        {
            daoColaborador.AtualizarColaborador(colaboradorModel);
            return true;
        }

        public async Task Inserir(ColaboradorModel colaboradorModel)
        {
            try
            {
                var colaboradorExiste = await daoColaborador.ColaboradorExiste(colaboradorModel.NomeColaborador);
                if (colaboradorExiste.NomeColaborador.Count() > 0)
                {
                    throw new ItemJaCadastrado();
                }
                else
                {
                    await daoColaborador.InserirColaborador(colaboradorModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ColaboradorModel> BuscaPorId(long idColaborador, long id_Empresa)
        {
            return await daoColaborador.ColaboradorPorId(idColaborador, id_Empresa);
        }

        public async Task Excluir(long idColaborador, long id_Empresa)
        {
            daoColaborador.ExcluirColaborador(idColaborador, id_Empresa);
        }
    }
}
