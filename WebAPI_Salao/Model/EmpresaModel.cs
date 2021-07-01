using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class EmpresaModel
    {
        public long IdEmpresa { get; set; }

        [Required(ErrorMessage = "Razão Social Não Pode Ser Vazia")]
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Um Nome Para Login é Obrigatorio")]
        public string LoginEmpresa { get; set; }

        [Required(ErrorMessage = "Uma Senha Para o Salão é Obrigatorio")]
        public string SenhaEmpresa { get; set; }
        public string LogoEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
    }
}

