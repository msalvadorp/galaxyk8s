using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpCliente.Services
{
    public interface IClienteServices
    {
        Task<CustomerBE> RecuperarPorId(int id);
        Task<CustomerBE> RecuperarPorDni(string nroDocumento);
    }
}
