using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data) => data.Gender is Enums.Gender.Male;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Gaming ", 1),
                new("Beer", 10),
                new("Book" , 5)
            };
    }
}
