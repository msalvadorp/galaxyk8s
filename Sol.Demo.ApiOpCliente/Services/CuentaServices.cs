using Microsoft.EntityFrameworkCore;
using Sol.Demo.ApiOpCliente.Contexto;
using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpCliente.Services
{
    public class CuentaServices : ICuentaServices
    {
        private readonly ClienteContext _clienteContext;

        public CuentaServices(ClienteContext clienteContext)
        {
            _clienteContext = clienteContext;
        }

        /// <summary>
        /// Galaxy Paso 01. Debes exponer este metodo via GRPC
        /// Agregamos el proto, creamos el servicios
        /// 
        /// Galaxy Paso 03 Crear un Dockerfile 
        /// Creas una imagen apiopcuenta
        /// Subes al Hub.docker
        /// 
        /// Galaxy Paso 04 Crear un archivo Yaml para usarlo en k8s
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
        public async Task<SaldoCuentaResponseBE> RecuperarSaldoIdCuenta(int idCuenta)
        {
            var res = await (from x in _clienteContext.Cuenta
                             where x.IdCuenta == idCuenta
                             select x.Saldo).FirstOrDefaultAsync();

            return new SaldoCuentaResponseBE(res);
        }

        public async Task<CustomerBE> RecuperarTitularIdCuenta(int idCuenta)
        {
            CustomerBE customerBE = null;

            var res = await (from x in _clienteContext.Cuenta.Include("Cliente")
                       where x.IdCuenta == idCuenta
                       select x.Cliente).FirstOrDefaultAsync();

            if (res != null)
            {
                customerBE = new CustomerBE(res);
            }

            return customerBE;
        }
    }
}
