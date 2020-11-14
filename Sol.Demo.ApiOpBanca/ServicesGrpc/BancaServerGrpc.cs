using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Sol.Demo.ApiOpBanca.Services;
using Sol.Demo.Banca.Protos;
using Sol.Demo.Comunes.BE;

namespace Sol.Demo.ApiOpBanca.ServicesGrpc
{
    [Authorize]
    public class BancaServerGrpc : BancaServiceGrpc.BancaServiceGrpcBase
    {
        private readonly ITransaccionServices transaccionServices;

        public BancaServerGrpc(ITransaccionServices transaccionServices)
        {
            this.transaccionServices = transaccionServices;
        }

        public override async Task<txResponse> ProcesaTransaccion(txRequest request, ServerCallContext context)
        {
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
