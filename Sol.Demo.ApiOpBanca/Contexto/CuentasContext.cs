using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sol.Demo.Comunes.DTO;

namespace Sol.Demo.ApiOpBanca.Contexto
{
    public class CuentasContext : DbContext
    {
        public CuentasContext(DbContextOptions<CuentasContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CuentaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
