using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Exceptions;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class ServicoRepository
    {
        private readonly DaoServico daoServico;

        public ServicoRepository()
        {
            daoServico = new DaoServico();
        }
        public List<ServicoModel> GetServicos()
        {
            return daoServico.GetServicos();
        }

        public async Task Inserir(ServicoModel servicoModel)
        {
            try
            {
                var servicoExiste = await daoServico.ServicoExiste(servicoModel.DescricaoServico);
                if (servicoExiste.DescricaoServico.Count() > 0)
                {
                    throw new ItemJaCadastrado();
                }
                else
                {
                    await daoServico.InserirServico(servicoModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Atualizar(ServicoModel servicoModel)
        {
            daoServico.AtualizarServico(servicoModel);
            return true;
        }

        public async Task<ServicoModel> BuscaPorId(long idServico, long id_Empresa)
        {
            return daoServico.GetServicoPorId(idServico, id_Empresa);
        }

        public void Excluir(long idServico, long id_Empresa)
        {
            daoServico.ExcluirServico(idServico, id_Empresa);
        }
    }
}
