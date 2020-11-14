using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiUxCustomer.Servicios;

namespace Sol.Demo.ApiUxCustomer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerServices _customerServices;

        public CustomerController(
            ILogger<CustomerController> logger, 
            ICustomerServices customerServices)
        {
            _logger = logger;
            _customerServices = customerServices;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaSaldo(int idCuenta) {

            var res = await _customerServices.ConsultaSaldo(idCuenta);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaClientePorDni(string nroDni)
        {

            var res = await _customerServices.RecuperarPorDNI(nroDni);
            return Ok(res);
        }
    }
}