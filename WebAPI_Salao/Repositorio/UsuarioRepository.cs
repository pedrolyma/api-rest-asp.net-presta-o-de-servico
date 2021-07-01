using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Salao.Dao;
using WebAPI_Salao.Model;

namespace WebAPI_Salao.Repositorio
{
    public class UsuarioRepository
    {
        private readonly DaoUsuario daoUsuario;
        public UsuarioRepository()
        {
            daoUsuario = new DaoUsuario();
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
             return daoUsuario.GetUsuarios();
        }

        public bool Inserir(UsuarioModel usuarioModel)
        {
            daoUsuario.InserirUsuario(usuarioModel);
            return true;
        }

        public bool Atualizar([FromBody] UsuarioModel usuarioModel)
        {
            daoUsuario.AtualizarUsuario(usuarioModel);
            return true;
        }

        public UsuarioModel BuscaPorId(long idUsuario)
        {
            return daoUsuario.GetUsuarioPorId(idUsuario);
        }

        public void Excluir(long idUsuario)
        {
            daoUsuario.ExcluirUsuario(idUsuario);
        }
    }
}
