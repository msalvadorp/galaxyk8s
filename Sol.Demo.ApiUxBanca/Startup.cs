using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sol.Demo.ApiUxBanca.Helpers;
using Sol.Demo.ApiUxBanca.Servicios;
using Sol.Demo.Comunes.Configs;

namespace Sol.Demo.ApiUxBanca
{
    public class Startup
    {
        //private readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
          ///this.logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string valor = Configuration.GetValue<string>("UrlApiCliente");
            ///logger.LogError("Llego UrlApiCliente " + valor);
            IdentityServerConfig config = Configuration
                .GetSection("IdentityServer").Get<IdentityServerConfig>();

            services.Configure<IdentityServerConfig>
                (Configuration.GetSection("IdentityServer"));

            //Usado para poder generar los Transient dinamicamente
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddTransient<ITokenAdapter, TokenAdapter>();

            //asociaciacion dinamica con el transientsegun el valos del header
            services.AddTransient<ITransactionServices>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                var header = context.Request.Headers["protocol"];
                if (string.IsNullOrEmpty(header) || header == "http")
                {
                    return new TransactionHttpServices
                        (serviceProvider.GetService<IConfiguration>());
                }
                else
                {
                    return new TransactionGrpcServces(
                        serviceProvider.GetService<ITokenAdapter>(),
                        serviceProvider.GetService<IConfiguration>()
                        );
                }
            });
            //services.AddTransient<ITransactionServices, TransactionGrpcServces>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            IdentityServerConfig config = Configuration
                .GetSection("IdentityServer").Get<IdentityServerConfig>();
            //app.UseHttpsRedirection();

            logger.LogWarning("Variables de IS4 " + JsonConvert.SerializeObject(config));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
