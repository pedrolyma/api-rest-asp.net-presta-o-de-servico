using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Salao.Exceptions
{
    public class ItemJaCadastrado : Exception
    {
        public ItemJaCadastrado()
        : base("Este Item ja esta Cadastrado")
        { }

    }
}
