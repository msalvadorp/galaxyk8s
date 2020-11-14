using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiUxBanca.Helpers
{
    public interface ITokenAdapter
    {
        Task<TokenResponseDTO> GeneraToken();
    }
}
