﻿using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly); });

            return services;
        }
    }
}
