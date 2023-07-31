using Microsoft.Extensions.Logging;
using PackIT.CommonAbstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Logging
{
    internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _handler;
        private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> handler, ILogger<LoggingCommandHandlerDecorator<TCommand>> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command)
        {
            var commandType = command.GetType();

            try
            {
                _logger.LogInformation($"Started processing {commandType} command.");
                await _handler.HandleAsync( command );
                _logger.LogInformation($"Finsihed processing {commandType} command.");

            }
            catch
            {
                _logger.LogError($"Failed to process {commandType} command.");
                throw;
            }
        }
    }
}
