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
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ApellidoMaterno = "Lopez", ApellidoPaterno = "Guerra", IdCliente = 1, Nombres = "Juan", NroDocumento = "12312312" },
                new Cliente { ApellidoMaterno = "Nieto", ApellidoPaterno = "Salguero", IdCliente = 2, Nombres = "Pedro", NroDocumento = "67676767" },
                new Cliente { ApellidoMaterno = "Gomez", ApellidoPaterno = "Perez", IdCliente = 3, Nombres = "Maria", NroDocumento = "44344344" }
                );

            modelBuilder.Entity<Cuenta>().HasData(
                new Cuenta {IdCliente = 1, IdCuenta = 1, Saldo = 120000 },
                new Cuenta { IdCliente = 3, IdCuenta = 2, Saldo = 80000 },
                new Cuenta { IdCliente = 2, IdCuenta = 3, Saldo = 660000 }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
