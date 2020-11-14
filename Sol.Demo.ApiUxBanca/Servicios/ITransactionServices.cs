using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxBanca.Servicios
{
    public interface ITransactionServices
    {

        Task<TxResponseBE> Transferir(TxRequestBE txRequestBE);
    }
}
