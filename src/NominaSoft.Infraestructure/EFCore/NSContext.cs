using Microsoft.EntityFrameworkCore;
using NominaSoft.Core.Entities;
using NominaSoft.Infraestructure.EFCore.Configurations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NominaSoft.Infraestructure.EFCore
{
    public class NSContext : DbContext
    {
        public NSContext(DbContextOptions<NSContext> options)
            : base(options) { }

        public DbSet<AFP> AFP { get; set; }
        public DbSet<BoletaPago> BoletaPago { get; set; }
        public DbSet<ConceptosDePago> ConceptoPago { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<PeriodoPago> PeriodoPago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AFPConfig());
            modelBuilder.ApplyConfiguration(new BoletaPagoConfig());
            modelBuilder.ApplyConfiguration(new ConceptoPagosConfig());
            modelBuilder.ApplyConfiguration(new ContratoConfig());
            modelBuilder.ApplyConfiguration(new PeriodoPagoConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
        }

        //Para soft delete
        private void ActualizarStatus()
        {
            foreach (var entidad in ChangeTracker.Entries())
            {
                switch (entidad.State)
                {
                    case EntityState.Added:
                        entidad.CurrentValues["Habilitado"] = true;
                        break;
                    case EntityState.Deleted:
                        entidad.State = EntityState.Modified;
                        entidad.CurrentValues["Habilitado"] = false;
                        break;
                }
            }
        }

        //Actualizar antes de guardar en la DB
        public override int SaveChanges()
        {
            ActualizarStatus();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken)
        {
            ActualizarStatus();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
