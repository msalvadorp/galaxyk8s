using Microsoft.EntityFrameworkCore;
using Sol.Demo.ApiOpCliente.Contexto;
using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpCliente.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ClienteContext _clienteContext;

        public ClienteServices(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        public async Task<CustomerBE> RecuperarPorDni(string nroDocumento)
        {
            CustomerBE customerBE = null;

            var res = await (from x in _clienteContext.Cliente
                       where x.NroDocumento == nroDocumento
                       select x).FirstOrDefaultAsync();

            if (res != null)
            {
                customerBE = new CustomerBE(res);
            }

            return customerBE;
        }

        public async Task<CustomerBE> RecuperarPorId(int id)
        {
            CustomerBE customerBE = null;

            var res = await (from x in _clienteContext.Cliente 
                       where x.IdCliente == id
                       select x).FirstOrDefaultAsync();

            if (res != null)
            {
                customerBE = new CustomerBE(res);
            }

            return customerBE;
        }
    }
}
