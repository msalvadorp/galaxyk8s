using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpBanca.Services
{
    public interface ITransaccionServices
    {

        Task<TxResponseBE> Transferir(TxRequestBE txRequestBE);
    }
}
