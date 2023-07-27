using PackIT.Application.DTOs.External;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherAsync(Localization localization);
    }
}
