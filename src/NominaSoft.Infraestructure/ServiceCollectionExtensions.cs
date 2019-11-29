using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NominaSoft.Infraestructure.EFCore;

namespace NominaSoft.Infraestructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NSContext>(options =>
              options.UseMySql(connectionString));
        }
    }
}
