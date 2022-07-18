using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class SalariosMap : IEntityTypeConfiguration<Salarios> 
    {
        public void Configure(EntityTypeBuilder<Salarios> builder)
        {
            builder.HasKey(s => s.SalarioId);
            builder.Property(s => s.Valor).IsRequired();
            //relc 1.1
            builder.HasOne(s => s.Meses)
                    .WithOne(s => s.Salarios)
                     .HasForeignKey<Salarios>(m => m.MesId);

            builder.ToTable("Salarios");
        }
    }
}
