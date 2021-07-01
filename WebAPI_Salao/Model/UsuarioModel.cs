using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class UsuarioModel
    {
        public long IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }

    }
}
