using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Seguridad.Configs
{
    public class IdentityConfig
    {

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
                new ApiScope("apibanca", "MyActions API"),
                new ApiScope("apicliente", "MyActions API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("apibanca", "MyActions API")
                {
                    Scopes = { "apibanca" }
                },
                new ApiResource("apicliente", "Obs API")
                {
                    Scopes = { "apicliente" }
                }
            };

        public static IEnumerable<Client> GetClients()
        {

            List<Client> listado = new List<Client>();

            Client c1 = new Client
            {
                ClientId = "appweb",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("123".Sha256()) },
                AllowedScopes = { "apibanca", "apicliente" }
            };

            listado.Add(c1);

            Client c2 = new Client
            {
                ClientId = "wsUxBanca",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("banca123".Sha256()) },
                AllowedScopes = { "apibanca", "apicliente" }
            };

            listado.Add(c2);

            return listado;
        }

        public static List<TestUser> GestUsers()
        {

            return new List<TestUser>{

            new TestUser {SubjectId = "1", Username = "jperez", Password="654321"},
            new TestUser {SubjectId = "2", Username = "mlopez", Password="654321"}
            };

        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId()
            };

        }
    }
}
