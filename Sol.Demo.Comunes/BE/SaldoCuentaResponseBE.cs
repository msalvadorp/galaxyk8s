using System;
using System.Collections.Generic;
using System.Text;

namespace Sol.Demo.Comunes.BE
{
    public class SaldoCuentaResponseBE
    {
        public SaldoCuentaResponseBE()
        {

        }

        public SaldoCuentaResponseBE(decimal amount)
        {
            Amount = amount;
            Date = DateTime.UtcNow;
        }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
