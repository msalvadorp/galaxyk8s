using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sol.Demo.ApiOpBanca.Contexto;
using Sol.Demo.ApiOpBanca.Services;
using Sol.Demo.ApiOpBanca.ServicesGrpc;
using Sol.Demo.Comunes.Configs;

namespace Sol.Demo.ApiOpBanca
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityServerConfig identityConfig =
               Configuration.GetSection("IdentityServer").Get<IdentityServerConfig>();

            string cadena = Configuration.GetValue<string>("ConnectionStrings:BDCliente");
            services.AddDbContext<CuentasContext>(options => {
                options.UseSqlServer(cadena);
            });

            services.AddTransient<ITransaccionServices, TransaccionServices>();

            services.AddControllers();
            services.AddGrpc();
            
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => {
                    options.Authority = identityConfig.UrlServer;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters =
                        new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                            ValidateAudience = false,
                            ValidateIssuer = false
                        };
                });


            services.AddAuthorization(opt => {

                opt.AddPolicy("Apiscope", pol => {
                    pol.RequireAuthenticatedUser();
                    pol.RequireClaim("scope", identityConfig.ResourceId);
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env, 
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityServerConfig config = Configuration
                      .GetSection("IdentityServer").Get<IdentityServerConfig>();

            logger.LogWarning("Llego IdentityServer " + Newtonsoft.Json.JsonConvert.SerializeObject(config));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BancaServerGrpc>();
                endpoints.MapControllers().RequireAuthorization("Apiscope");
            });
        }
    }
}
