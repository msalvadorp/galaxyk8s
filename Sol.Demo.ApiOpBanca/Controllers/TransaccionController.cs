using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiOpBanca.Services;
using Sol.Demo.Comunes.BE;

namespace Sol.Demo.ApiOpBanca.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TransaccionController : ControllerBase
    {
        private readonly ILogger<TransaccionController> _logger;
        private readonly ITransaccionServices _transaccionServices;

        public TransaccionController(ILogger<TransaccionController> logger, 
            ITransaccionServices transaccionServices)
        {
            _logger = logger;
            _transaccionServices = transaccionServices;
        }

        [HttpPost]
        public async Task<IActionResult> ProcesarTx(TxRequestBE txRequestBE) {


            var result = await _transaccionServices.Transferir(txRequestBE);
            return Ok(result);
        }
    }
}