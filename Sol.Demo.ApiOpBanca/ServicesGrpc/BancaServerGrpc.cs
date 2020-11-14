using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiOpBanca.Services;
using Sol.Demo.Banca.Protos;
using Sol.Demo.Comunes.BE;

namespace Sol.Demo.ApiOpBanca.ServicesGrpc
{
    [Authorize]
    public class BancaServerGrpc : BancaServiceGrpc.BancaServiceGrpcBase
    {
        private readonly ITransaccionServices transaccionServices;
        private readonly ILogger<BancaServerGrpc> logger;

        public BancaServerGrpc(
            ITransaccionServices transaccionServices,
            ILogger<BancaServerGrpc> logger)
        {
            this.transaccionServices = transaccionServices;
            this.logger = logger;
        }

        public override async Task<txResponse> ProcesaTransaccion
            (txRequest request, ServerCallContext context)
        {
            logger.LogWarning("Llego a opbanca grpc");

            TxRequestBE be = new TxRequestBE()
            {
                IdCuentaDestino = request.IdCuentaDestino,
                IdCuentaOrigen = request.IdCuentaDestino,
                Monto = (decimal)request.Monto
            };
            TxResponseBE resp = await transaccionServices.Transferir(be);
            txResponse txRpta = new txResponse()
            {
                IdOperacion = resp.OperationCode
            };
            return txRpta;
        }

    }
}
