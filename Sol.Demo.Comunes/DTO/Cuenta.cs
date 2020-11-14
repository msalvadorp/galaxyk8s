using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sol.Demo.Comunes.DTO
{
    public class Cuenta
    {
        [Key]
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public decimal Saldo { get; set; }

        public Cliente Cliente { get; set; }
    }
}
