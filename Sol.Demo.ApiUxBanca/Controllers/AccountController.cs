using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol.Demo.ApiUxBanca.Servicios;
using Sol.Demo.Comunes.BE;

namespace Sol.Demo.ApiUxBanca.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;

        public AccountController(ITransactionServices transactionServices)
        {
            this._transactionServices = transactionServices;
        }

        [HttpPost]
        public async Task<IActionResult> ProcesaTransferencia
            ([FromBody] TxRequestBE txRequestBE)
        {
            var resp = await _transactionServices.Transferir(txRequestBE);
            return Ok(resp);

        }
    }
}