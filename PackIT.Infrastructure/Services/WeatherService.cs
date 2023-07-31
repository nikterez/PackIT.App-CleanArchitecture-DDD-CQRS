using PackIT.Application.DTOs.External;
using PackIT.Application.Services;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Services
{
    internal sealed class WeatherService : IWeatherService
    {
        public Task<WeatherDTO> GetWeatherAsync(Localization localization) => Task.FromResult(new WeatherDTO( new Random().Next(5, 30)));
    }
}
