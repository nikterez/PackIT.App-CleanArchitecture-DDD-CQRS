﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Common.Exceptions;
using PackIT.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<ApplicationInitializer>();
            services.AddScoped<ExceptionMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app) 
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
