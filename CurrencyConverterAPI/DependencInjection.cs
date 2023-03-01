using CurrencyConverterAPI.Common.Mapper;

namespace CurrencyConverterAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            return services;
        }
    }
}
