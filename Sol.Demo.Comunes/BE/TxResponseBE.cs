using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sol.Demo.Comunes.BE
{
    public class TxResponseBE
    {
        public TxResponseBE()
        {

        }


        public TxResponseBE(Transaccion transaccion)
        {
            OperationCode = transaccion.IdTransaccion;
            Date = transaccion.FechaOperacion;
            Amount = transaccion.Monto;
        }
        public int OperationCode { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
       
    }
}
