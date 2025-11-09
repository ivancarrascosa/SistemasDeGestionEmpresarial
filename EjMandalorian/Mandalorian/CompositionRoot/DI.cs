using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;
using Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Aquí puedes agregar las configuraciones de inyección de dependencias
            // Por ejemplo:
            services.AddTransient<IUseCase, ListadoMisionesUseCase>();
            services.AddTransient<IRepository, RepositoryMisiones>();
            return services;
        }
    }
}
