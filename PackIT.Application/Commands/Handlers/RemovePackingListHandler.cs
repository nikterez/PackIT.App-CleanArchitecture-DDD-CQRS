﻿using PackIT.Application.Exceptions;
using PackIT.CommonAbstractions.Commands;
using PackIT.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class RemovePackingListHandler : ICommandHandler<RemovePackingList>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingListHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemovePackingList command)
        {
            var packingList = await _repository.GetByIdAsync(command.Id) ?? throw new PackingListNotFoundException(command.Id);
            
            await _repository.DeleteAsync(packingList.Id);
        }
    }
}
