using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiOpCliente.Services;
using Sol.Demo.Comunes.BE;

namespace Sol.Demo.ApiOpCliente.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private readonly ILogger<CuentaController> _logger;
        private readonly ICuentaServices _cuentaServices;

        public CuentaController(ILogger<CuentaController> logger, ICuentaServices cuentaServices)
        {
            _logger = logger;
            _cuentaServices = cuentaServices;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarClienteCuenta(int idCuenta)
        {

            var res = await _cuentaServices.RecuperarTitularIdCuenta(idCuenta);

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarSaldoCuenta(int idCuenta)
        {

            SaldoCuentaResponseBE res = await _cuentaServices.RecuperarSaldoIdCuenta(idCuenta);

            return Ok(res);
        }
    }
}