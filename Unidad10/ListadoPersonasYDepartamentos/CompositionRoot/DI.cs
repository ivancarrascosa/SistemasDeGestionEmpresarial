using Data.Repositories;
using Domain.Repositories;
using Domain.UseCase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DI
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            //Registrar repositorios concretos
            services.AddScoped<IGetListaPersonas, PersonasRepositoryAzure>();

            //Registrar casos de uso
            services.AddScoped<IGetListaPersonasUseCase, DefaultGetListaPersonasUseCase>();

            return services;
        }
    }
}
