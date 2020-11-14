using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxBanca.Servicios
{
    public class TransactionHttpServices : ITransactionServices
    {
        private readonly IConfiguration configuration;

        public TransactionHttpServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<TxResponseBE> Transferir(TxRequestBE txRequestBE)
        {


            string url = configuration.GetValue<string>("UrlApiCliente");
            string ruta = url + "transaccion/ProcesarTx";
            //    + codCuenta.ToString();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(txRequestBE), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ruta, content);
            TxResponseBE rpta =
                await response.Content.ReadAsAsync<TxResponseBE>();

            return rpta;
        }
    }
}
