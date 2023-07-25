using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data) => data.Temperature > 80;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Hat",1),
                new("Sunglasses", 1),
                new("Water Bottle", 3)
            };
    }
}
