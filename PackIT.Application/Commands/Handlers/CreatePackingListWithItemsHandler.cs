using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.CommonAbstractions.Commands;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, IPackingListReadService services, IWeatherService weatherService)
        {
            _repository = repository;
            _factory = factory;
            _readService = services;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;
            
            if(await _readService.CheckPackingListExistsbyName(name))
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            
            var weather = await _weatherService.GetWeatherAsync(localization) ?? throw new MissingLocalizationWeatherException(localization);

            var packingList = _factory.CreateWithDefaultItems(id, name, localization, days, gender, weather.Temperature);

            await _repository.AddAsync(packingList);  
        }
    }
}
