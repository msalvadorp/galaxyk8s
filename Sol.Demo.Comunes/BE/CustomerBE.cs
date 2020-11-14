using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sol.Demo.Comunes.BE
{
    public class CustomerBE
    {
        public CustomerBE()
        {

        }
        public CustomerBE(Cliente cliente)
        {
            Code = cliente.IdCliente;
            Names = $"{ cliente.ApellidoPaterno } {cliente.ApellidoMaterno} {cliente.Nombres}";
            DocumentCode = cliente.NroDocumento;
        }
        public int Code { get; set; }
        public string Names { get; set; }
        public string DocumentCode { get; set; }

    }
}
