using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Demo.Comunes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Demo.ApiOpCliente.Contexto
{
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(u => new { u.IdCuenta });


            builder.HasOne<Cliente>(s => s.Cliente)
            .WithMany(ad => ad.Cuenta)
            .HasForeignKey(ad => ad.IdCliente);

        }
    }
}
