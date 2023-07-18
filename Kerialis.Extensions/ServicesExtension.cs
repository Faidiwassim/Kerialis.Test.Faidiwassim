using Kerialis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IExpenseService, ExpenseService>();
            return services;
        }
    }
}
