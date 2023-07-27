using PackIT.CommonAbstractions.Exceptions;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; }
        
        public MissingLocalizationWeatherException(Localization localization) : base($"Unable to fetch weather data for localization '{localization.City}/{localization.Country}'.")
        {
            Localization = localization;
        }

    }
}
