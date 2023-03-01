using CurrencyConverter.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.EFCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            var st = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CurrencyConverterDbContext>(options =>
            {
                options.UseMySql(st, ServerVersion.AutoDetect(st));
            });

            return services;
        }
    }
}
