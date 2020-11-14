using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpCliente.Services
{
    public interface ICuentaServices
    {
        Task<CustomerBE> RecuperarTitularIdCuenta(int idCuenta);
        Task<SaldoCuentaResponseBE> RecuperarSaldoIdCuenta(int idCuenta);
    }
}
