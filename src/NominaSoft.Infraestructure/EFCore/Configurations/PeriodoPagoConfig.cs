using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class PeriodoPagoConfig : IEntityTypeConfiguration<PeriodoPago>
    {
        public void Configure(EntityTypeBuilder<PeriodoPago> builder)
        {
            builder.HasKey(pp => pp.IdPeriodoPago);

            //builder.HasMany(pp => pp.BoletasPago)
            //       .WithOne(bp => bp.PeriodoPago)
            //       .HasForeignKey(bp => bp.IdPeriodoPago)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(pp => pp.ConceptosPago)
            //       .WithOne(cp => cp.PeriodoPago)
            //       .HasForeignKey(cp => cp.IdPeriodoPago)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(pp => EF.Property<bool>(pp, "Habilitado") == true);
        }
    }
}
