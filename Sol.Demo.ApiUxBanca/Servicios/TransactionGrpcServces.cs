using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.AspNetCore;
using Sol.Demo.Banca.Protos;
using Grpc.Net.Client;
using System.Threading.Channels;
using System.Net.Http;
using Grpc.Core;
using Sol.Demo.ApiUxBanca.Helpers;
using Sol.Demo.Comunes.DTO;
using Microsoft.Extensions.Configuration;

namespace Sol.Demo.ApiUxBanca.Servicios
{
    public class TransactionGrpcServces : ITransactionServices
    {
        private readonly ITokenAdapter tokenAdapter;
        private readonly IConfiguration configuration;

        public TransactionGrpcServces(ITokenAdapter tokenAdapter, 
            IConfiguration configuration)
        {
            this.tokenAdapter = tokenAdapter;
            this.configuration = configuration;
        }
        public async Task<TxResponseBE> Transferir(TxRequestBE txRequestBE)
        {

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var miHttpClient = new HttpClient(handler);

            TokenResponseDTO responseToken = await tokenAdapter.GeneraToken();

            var metadata = new Metadata();
            metadata.Add("Authorization", $"Bearer {responseToken.Token}");

            var channel = GrpcChannel.ForAddress
                (configuration.GetValue<string>("UrlApiCliente"), 
                new GrpcChannelOptions { HttpClient = miHttpClient});

            BancaServiceGrpc.BancaServiceGrpcClient client =
                new BancaServiceGrpc.BancaServiceGrpcClient(channel);

            txRequest request = new txRequest()
            {
                IdCuentaDestino = txRequestBE.IdCuentaDestino,
                IdCuentaOrigen = txRequestBE.IdCuentaOrigen,
                Monto = (double)txRequestBE.Monto
            };
            txResponse response = await client.ProcesaTransaccionAsync
                (request, headers: metadata);

            TxResponseBE txResponseBE = new TxResponseBE() {
                Amount = txRequestBE.Monto,
                Date = DateTime.Now,
                OperationCode = response.IdOperacion
            };

            return txResponseBE;
        }
    }
}
