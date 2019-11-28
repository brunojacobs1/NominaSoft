using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class BoletaPagoConfig : IEntityTypeConfiguration<BoletaPago>
    {
        public void Configure(EntityTypeBuilder<BoletaPago> builder)
        {
            builder.HasKey(bp => bp.IdBoletaPago);


            builder.HasOne(bp => bp.ConceptosDePago)
                   .WithOne()
                   .HasForeignKey("BoletaPago", "IdConceptosDePago")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bp => bp.PeriodoPago)
                   .WithMany()
                   .HasForeignKey("IdPeriodoPago")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bp => bp.Contrato)
                   .WithMany()
                   .HasForeignKey("IdContrato")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(bp => EF.Property<bool>(bp, "Habilitado") == true);
        }
    }
}
