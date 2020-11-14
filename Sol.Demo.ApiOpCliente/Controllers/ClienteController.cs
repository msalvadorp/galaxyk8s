using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiOpCliente.Services;

namespace Sol.Demo.ApiOpCliente.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteServices _clienteServices;

        public ClienteController(ILogger<ClienteController> logger, IClienteServices clienteServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarPorDni(string nroDocumento) {

            var res = await _clienteServices.RecuperarPorDni(nroDocumento);
           
            return Ok(res);
        }
    }
}