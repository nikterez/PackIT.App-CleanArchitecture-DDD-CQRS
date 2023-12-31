﻿using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data) => data.Temperature < 5;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Jacket", 1),
                new("Scarf",1),
                new("Gloves", 1),
            };
    }
}
