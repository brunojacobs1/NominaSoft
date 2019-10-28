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

            //builder.HasOne(bp => bp.ConceptosDePago)
            //       .WithOne(cp => cp.BoletaPago)
            //       .HasForeignKey<ConceptosDePago>(cp => cp.IdBoletaPago)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(bp => EF.Property<bool>(bp, "Habilitado") == true);
        }
    }
}
