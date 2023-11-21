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
            services.AddScoped<IReceitaEntradaRepository, ReceitaEntradaRepository>();
            services.AddScoped<IReceitaSaidaRepository, ReceitaSaidaRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IReceitaEntradaService, ReceitaEntradaService>();
            services.AddScoped<IReceitaSaidaService, ReceitaSaidaService>();

            return services;
        }

    }
}
