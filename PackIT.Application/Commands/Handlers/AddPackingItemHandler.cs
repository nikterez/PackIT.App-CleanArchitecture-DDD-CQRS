﻿using PackIT.Application.Exceptions;
using PackIT.CommonAbstractions.Commands;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddPackingItem command)
        {
            var packingList = await _repository.GetByIdAsync(command.PackingListId) ?? throw new PackingListNotFoundException(command.PackingListId);
            var packingItem = new PackingItem(command.Name, command.Quantity);
            
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}

