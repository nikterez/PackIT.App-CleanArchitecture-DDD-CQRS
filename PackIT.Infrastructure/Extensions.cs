
using Microsoft.Extensions.DependencyInjection;
using PackIT.Common.Queries;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddQueries();
            
            return services;
        }
    }
}
