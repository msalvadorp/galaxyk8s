using Microsoft.Extensions.Configuration;
using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxCustomer.Servicios
{
    public class CustomerHttpServices : ICustomerServices
    {
        private readonly IConfiguration configuration;

        public CustomerHttpServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<SaldoCuentaResponseBE> ConsultaSaldo(int codCuenta)
        {
            string url = configuration.GetValue<string>("UrlApiCliente");
            string ruta = url + "cuenta/RecuperarSaldoCuenta?idCuenta=" 
                + codCuenta.ToString();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(ruta);
            SaldoCuentaResponseBE rpta = 
                await response.Content.ReadAsAsync<SaldoCuentaResponseBE>();

            return rpta;
        }

        public Task<CustomerBE> RecuperarPorDNI(string nroDocumento)
        {
            throw new NotImplementedException();
        }
    }
}
