using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sol.Seguridad.Configs;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Sol.Seguridad
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironmentv;

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironmentv)
        {
            this.configuration = configuration;
            this.webHostEnvironmentv = webHostEnvironmentv;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var cert = new X509Certificate2
                (Path.Combine(webHostEnvironmentv.ContentRootPath, 
                configuration["IdentityServer:FileName"]),
                configuration["IdentityServer:Password"], 
                X509KeyStorageFlags.MachineKeySet);

            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
                .AddInMemoryApiResources(IdentityConfig.ApiResources)
                .AddInMemoryClients(IdentityConfig.GetClients())
                .AddTestUsers(IdentityConfig.GestUsers())
                .AddSigningCredential(cert)
                //.AddDeveloperSigningCredential()
                ;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
