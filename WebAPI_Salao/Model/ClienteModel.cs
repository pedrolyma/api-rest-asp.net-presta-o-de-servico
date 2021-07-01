using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class ClienteModel
    {
        public long IdCliente { get; set; }
        [Required(ErrorMessage = "Nome do Cliente Não Pode Ficar Vazio")]
        [StringLength(150, ErrorMessage = "O nome do Cliente de Ter de 2 a 150 Caracteres", MinimumLength = 2)]
        public string NomeCliente { get; set; }
        public string Logradouro { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public string TikTok { get; set; }
        public string Twitter { get; set; }
        public string Instagran { get; set; }
        public long id_Empresa { get; set; }
        public virtual EmpresaModel Empresa { get; set; }
    }
}
