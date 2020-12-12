using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sol.Demo.ApiUxBanca.Helpers;
using Sol.Demo.Comunes.BE;
using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxBanca.Servicios
{
    public class TransactionHttpServices : ITransactionServices
    {
        private readonly ITokenAdapter tokenAdapter;
        private readonly IConfiguration configuration;

        public TransactionHttpServices(ITokenAdapter tokenAdapter, IConfiguration configuration)
        {
            this.tokenAdapter = tokenAdapter;
            this.configuration = configuration;
        }
        public async Task<TxResponseBE> Transferir(TxRequestBE txRequestBE)
        {


            string url = configuration.GetValue<string>("UrlApiCliente");
            string ruta = url + "transaccion/ProcesarTx";
            //    + codCuenta.ToString();
            TokenResponseDTO responseToken = await tokenAdapter.GeneraToken();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", responseToken.Token);

            StringContent content = new StringContent(JsonConvert.SerializeObject(txRequestBE), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ruta, content);
            TxResponseBE rpta =
                await response.Content.ReadAsAsync<TxResponseBE>();

            return rpta;
        }
    }
}
