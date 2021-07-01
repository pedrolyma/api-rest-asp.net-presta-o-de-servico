using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Model
{
    public class ColaboradorModel
    {
        public long IdColaborador { get; set; }
        public string NomeColaborador { get; set; }
        public string WhatsAppColaborador { get; set; }
        public string TikTokColaborador { get; set; }
        public string TwitterColaborador { get; set; }
        public string InstagranColaborador { get; set; }
        public string FotoColaborador { get; set; }
        public long id_Empresa { get; set; }
    }
}
