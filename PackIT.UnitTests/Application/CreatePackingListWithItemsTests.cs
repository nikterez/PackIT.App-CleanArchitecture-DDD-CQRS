using NSubstitute;
using PackIT.Application.Commands;
using PackIT.Application.Services;
using PackIT.Application.Commands.Handlers;
using PackIT.CommonAbstractions.Commands;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PackIT.Domain.Enums;
using Shouldly;
using PackIT.Application.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Application.DTOs.External;
using PackIT.Domain.Entities;

namespace PackIT.UnitTests.Application
{
    public class CreatePackingListWithItemsTests
    {
        Task Act(CreatePackingListWithItems command) => _handler.HandleAsync(command);

        [Fact]
        public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_Same_Name_Exists()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems(Guid.NewGuid(),"MyList",10,Gender.Female,default);
            _readService.CheckPackingListExistsbyName(command.Name).Returns(true);

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsException>();
        }

        [Fact]
        public async Task Handle_Async_Throws_MissingLocalozationWeatherException_When_Wheather_Not_Retured_From_Service()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, new LocalizationWriteModel("Athens","Greece"));

            _readService.CheckPackingListExistsbyName(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDTO));

            //ACT
            var exception = await Record.ExceptionAsync(()=>Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();

        }

        [Fact]
        public async Task Handle_Async_Calls_Repository_On_Success()
        {
            //ARRANGE
            var command = new CreatePackingListWithItems(Guid.NewGuid(), "MyList", 10, Gender.Female, new LocalizationWriteModel("Athens", "Greece"));

            _readService.CheckPackingListExistsbyName(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDTO(12));
            _factory.CreateWithDefaultItems(command.Id,command.Name,Arg.Any<Localization>(),command.Days,command.Gender,Arg.Any<Temperature>()).Returns(default(PackingList));

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(default(PackingList));

        }

        #region ARRANGE

        private readonly ICommandHandler<CreatePackingListWithItems> _handler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsTests()
        {
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();

            _handler = new CreatePackingListWithItemsHandler(_repository, _factory, _readService, _weatherService);
        }
        #endregion
    }
}
