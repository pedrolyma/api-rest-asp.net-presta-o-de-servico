using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class EmpresaRepository
    {
        private readonly DaoEmpresa daoEmpresa;
        public EmpresaRepository()
        {
            daoEmpresa = new DaoEmpresa();
        }

        public List<EmpresaModel> GetEmpresas()
        {
            return daoEmpresa.GetEmpresas();
        }

        public bool Inserir(EmpresaModel empresaModel)
        {
            daoEmpresa.InserirEmpresa(empresaModel);
            return true;
        }

        public bool Atualizar(EmpresaModel empresaModel)
        {
            daoEmpresa.AtualizarEmpresa(empresaModel);
            return true;
        }

        public EmpresaModel BuscaPorId(long idEmpresa)
        {
            return daoEmpresa.GetEmpresaPorId(idEmpresa);
        }

        public void Excluir(long idEmpresa)
        {
            daoEmpresa.ExcluirEmpresa(idEmpresa);
        }
    }
}
