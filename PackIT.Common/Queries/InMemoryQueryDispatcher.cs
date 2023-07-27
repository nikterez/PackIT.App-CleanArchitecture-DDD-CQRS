using Microsoft.Extensions.DependencyInjection;
using PackIT.CommonAbstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Common.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            using var scope = _serviceProvider.CreateScope();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), (typeof(TResult)));

            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            //4:42 wtf is this even lel
            return await (Task<TResult>) handlerType.GetMethod("HandleAsync")?.Invoke(handler, new[] { query });
        }
    }
}
