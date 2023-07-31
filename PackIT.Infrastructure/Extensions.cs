
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Common.Options;
using PackIT.Common.Queries;
using PackIT.Domain.Repositories;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Options;
using PackIT.Infrastructure.Data.Services;
using PackIT.Infrastructure.Repositories;
using PackIT.Infrastructure.Services;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddPostgres(config);
            services.AddQueries();
            services.AddServices();
            
            return services;
        }

        private static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPackingListRepository, PostgresPackingListsRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

            var options = config.GetOptions<PostgresOptions>("Postgres");

            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseNpgsql(options.ConnectionString));
            
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseNpgsql(options.ConnectionString));

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IWeatherService, WeatherService>();

            return services;
        }
    }
}
