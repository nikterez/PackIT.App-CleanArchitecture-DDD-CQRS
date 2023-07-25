using PackIT.Domain.Enums;

namespace PackIT.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Daysm, Gender Gender, LocalizationWriteModel Localization) : CommonAbstractions.Commands.ICommand;

    public record LocalizationWriteModel(string City, string Country);

}
