using PackIT.CommonAbstractions.Domain;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Events
{
    public record PackingItemPacked(PackingList PackingList, PackingItem PackingItem) :IDomainEvent;
}
