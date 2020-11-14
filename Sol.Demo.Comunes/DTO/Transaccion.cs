using Sol.Demo.Comunes.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sol.Demo.Comunes.DTO
{
    public class Transaccion
    {
        public Transaccion()
        {

        }

        public Transaccion(TxRequestBE txRequestBE)
        {
            IdCuentaOrigen = txRequestBE.IdCuentaOrigen;
            IdCuentaDestino = txRequestBE.IdCuentaDestino;
            Monto = txRequestBE.Monto;
            FechaOperacion = DateTime.Now;
        }
        [Key]
        public int IdTransaccion { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaOperacion { get; set; }
    }
}
