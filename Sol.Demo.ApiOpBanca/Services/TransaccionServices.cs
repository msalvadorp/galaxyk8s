using Sol.Demo.ApiOpBanca.Contexto;
using Sol.Demo.Comunes.BE;
using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sol.Demo.ApiOpBanca.Services
{
    public class TransaccionServices : ITransaccionServices
    {
        private readonly CuentasContext _cuentasContext;

        public TransaccionServices(CuentasContext cuentasContext)
        {
            _cuentasContext = cuentasContext;
        }
        public  async Task<TxResponseBE> Transferir(TxRequestBE txRequestBE)
        {
            #region Origen

            var origen = await (from x in _cuentasContext.Cuenta
                          where x.IdCuenta == txRequestBE.IdCuentaOrigen
                          select x).FirstOrDefaultAsync();
            origen.Saldo -= txRequestBE.Monto;

            #endregion


            #region Operacion
            Transaccion tx = new Transaccion(txRequestBE);
            _cuentasContext.Transaccion.Add(tx);

            #endregion

            #region Destino

            var destino = await (from x in _cuentasContext.Cuenta
                          where x.IdCuenta == txRequestBE.IdCuentaDestino
                          select x).FirstOrDefaultAsync();
            destino.Saldo += txRequestBE.Monto;

            #endregion

            await _cuentasContext.SaveChangesAsync();

            TxResponseBE resp = new TxResponseBE(tx);

            return resp;
        }
    }
}
