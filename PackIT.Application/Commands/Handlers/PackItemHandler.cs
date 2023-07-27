using PackIT.Application.Exceptions;
using PackIT.CommonAbstractions.Commands;
using PackIT.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }
     
        public async Task HandleAsync(PackItem command)
        {
            var packingList = await _repository.GetByIdAsync(command.PackingListId) ?? throw new PackingListNotFoundException(command.PackingListId);
            
            packingList.PackItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
