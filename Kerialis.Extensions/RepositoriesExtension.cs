using Kerialis.Datas.DbContexts;
using Kerialis.Repositories.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryFactory<KerialisContext>, RepositoryFactory<KerialisContext>>();
            return services;
        }
    }
}
