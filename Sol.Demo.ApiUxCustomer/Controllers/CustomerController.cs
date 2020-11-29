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

        /// <summary>
        /// Galaxy Paso 2 Este metodo debe llamar al ApiOpCliente via GRPC
        /// Galaxy Paso 5.- Crearle el Dockerfile y creas una imagen llamada apiuxcustomer
        /// Subes al hubDocker
        /// Galaxy Paso 6.- Crear el yml para subirlo al k8s
        /// Opcional Galaxy Paso 7-- Federar la aplucacion para que use el identityserver de la ApiSeguridad
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <returns></returns>
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