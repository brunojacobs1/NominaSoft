using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NominaSoft.Infraestructure.EFCore;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.UseCases;

namespace NominaSoft.Infraestructure
{
    public static class ServiceConfigurationExtension
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<NSContext>(options =>
              options.UseMySql(connectionString));
        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<AFP>, Repository<AFP>>();
            services.AddTransient<IRepository<BoletaPago>, Repository<BoletaPago>>();
            services.AddTransient<IRepository<ConceptosDePago>, Repository<ConceptosDePago>>();
            services.AddTransient<IRepository<Contrato>, Repository<Contrato>>();
            services.AddTransient<IRepository<Empleado>, Repository<Empleado>>();
            services.AddTransient<IRepository<PeriodoPago>, Repository<PeriodoPago>>();
            services.AddTransient<IGestionarContratoUC, GestionarContratoUC>();
            services.AddTransient<IProcesarPagosUC, ProcesarPagosUC>();
        }
    }
}
