using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays TravelDays, Enums.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization);
}
