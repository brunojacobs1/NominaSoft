using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class AFPConfig : IEntityTypeConfiguration<AFP>
    {
        public void Configure(EntityTypeBuilder<AFP> builder)
        {
            builder.HasKey(a => a.IdAFP);
            builder.Property(a => a.NombreAFP).HasMaxLength(50).IsRequired();

            //builder.HasMany(a => a.Contratos)
            //       .WithOne(c => c.AFP)
            //       .HasForeignKey(c => c.IdAFP)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(a => EF.Property<bool>(a, "Habilitado") == true);
        }
    }
}
