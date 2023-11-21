using DevIoBusiness.Interfaces;
using DevIoBusiness.Services;
using DevIoData.Context;
using DevIoData.Repository;

namespace DevIOApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();


            services.AddScoped<IClienteRepository, ClienteRepository>();



            services.AddScoped<IClienteService, ClienteService>();


            return services;
        }

    }
}
