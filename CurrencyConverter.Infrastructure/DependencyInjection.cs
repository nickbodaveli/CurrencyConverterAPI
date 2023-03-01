using CurrencyConverter.Application.Common.Interfaces.Persistence;
using CurrencyConverter.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<ICurrencyConverterRepository, CurrencyConverterRepository>();
            return services;
        }
    }
}
