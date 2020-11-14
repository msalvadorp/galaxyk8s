using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxCustomer.Servicios
{
    public interface ICustomerServices
    {
        Task<SaldoCuentaResponseBE> ConsultaSaldo(int codCuenta);
        Task<CustomerBE> RecuperarPorDNI(string nroDocumento);
    }
}
