
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Common.Options;
using PackIT.Common.Queries;
using PackIT.Infrastructure.Data.Contexts;
using PackIT.Infrastructure.Data.Options;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddPostgres(config);
            services.AddQueries();
            
            return services;
        }

        private static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration config)
        {
            var options = config.GetOptions<PostgresOptions>("Postgres");

            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseNpgsql(options.ConnectionString));
            
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}
