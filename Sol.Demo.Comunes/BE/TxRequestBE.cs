using System;
using System.Collections.Generic;
using System.Text;

namespace Sol.Demo.Comunes.BE
{
    public class TxRequestBE
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }

    }
}
