using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class ConceptoPagosConfig : IEntityTypeConfiguration<ConceptosDePago>
    {
        public void Configure(EntityTypeBuilder<ConceptosDePago> builder)
        {
            builder.HasKey(cp => cp.IdConceptosDePago);

            //builder.HasOne(cp => cp.BoletaPago)
            //       .WithOne(bp => bp.ConceptosDePago)
            //       .HasForeignKey<BoletaPago>(bp => bp.IdConceptosDePago)
            //       .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cp => cp.Contrato)
                   .WithMany()
                   .HasForeignKey("IdContrato")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.PeriodoPago)
                   .WithMany()
                   .HasForeignKey("IdPeriodoPago")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(cp => EF.Property<bool>(cp, "Habilitado") == true);
        }
    }
}
