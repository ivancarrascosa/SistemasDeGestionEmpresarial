using Data.Repositories;
using Domain.Interfaces;
using Domain.Repositories; 
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //Registrar repositorios concretos
            services.AddScoped<IRepository, PersonasRepositoryAzure>();

            //Registrar casos de uso
            services.AddScoped<IUseCase, DefaultUseCase>();

            return services;
        }
    }
}
