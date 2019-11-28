using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class ContratoConfig : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(c => c.IdContrato);
            builder.Property(c => c.Cargo).HasMaxLength(50);

            //builder.HasMany(c => c.ConceptosDePago)
            //       .WithOne(cp => cp.Contrato)
            //       .HasForeignKey(cp => cp.IdContrato)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(c => c.BoletasPago)
            //       .WithOne(bp => bp.Contrato)
            //       .HasForeignKey(bp => bp.IdContrato)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.AFP)
                   .WithMany()
                   .HasForeignKey("IdAFP")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Empleado)
                   .WithMany()
                   .HasForeignKey("IdEmpleado")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(c => EF.Property<bool>(c, "Habilitado") == true);
        }
    }
}
