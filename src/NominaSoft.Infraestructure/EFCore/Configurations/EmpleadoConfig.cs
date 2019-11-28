using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Infraestructure.EFCore.Configurations
{
    internal class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.IdEmpleado);
            builder.Property(e => e.NombreEmpleado).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Dni).HasMaxLength(8).IsRequired();
            builder.Property(e => e.Direccion).HasMaxLength(80);

            //builder.HasMany(e => e.Contratos)
            //       .WithOne(c => c.Empleado)
            //       .HasForeignKey(c => c.IdEmpleado)
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(e => EF.Property<bool>(e, "Habilitado") == true);
        }
    }
}
