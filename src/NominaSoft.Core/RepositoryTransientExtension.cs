using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Entities;

namespace NominaSoft.Core
{
    public static class RepositoryTransientExtension
    {
        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<AFP>, Repository<AFP>>();
            services.AddTransient<IRepository<BoletaPago>, Repository<BoletaPago>>();
            services.AddTransient<IRepository<ConceptosDePago>, Repository<ConceptosDePago>>();
            services.AddTransient<IRepository<Contrato>, Repository<Contrato>>();
            services.AddTransient<IRepository<Empleado>, Repository<Empleado>>();
            services.AddTransient<IRepository<PeriodoPago>, Repository<PeriodoPago>>();
        }
    }
}
