﻿using Microsoft.Extensions.DependencyInjection;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}