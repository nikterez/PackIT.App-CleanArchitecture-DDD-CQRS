using PackIT.Domain.Entities;
using PackIT.Domain.Enums;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
        {
            _policies = policies;
        }

        public PackingList Create(PackingListId id, PackingListName name, Localization localization) => new(id, name, localization);

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, Localization localization, TravelDays days, Gender gender, Temperature temperature)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolices = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolices.SelectMany(p => p.GenerateItems(data));
            var packingList = Create(id, name, localization);

            packingList.AddItems(items);

            return packingList;
        }
    }
}
