using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class ServicoModel
    {
        public int IdServico { get; set; }
        [Required(ErrorMessage = "A Descrição do Serviço e Obrigatorio")]
        [StringLength(150, ErrorMessage = "Descrição deve de 2 a 150 Caracteres", MinimumLength = 2)]
        public string DescricaoServico { get; set; }
        public decimal ValorServico { get; set; }
        public string TempoServico { get; set; }
        public string MaterialServico { get; set; }
        public string Cuidados { get; set; }
        public long id_Empresa { get; set; }
        public virtual EmpresaModel Empresa { get; set; }
    }
}
