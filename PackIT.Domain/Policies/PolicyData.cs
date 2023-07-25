using PackIT.Domain.Enums;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays TravelDays, Enums.Gender Gender, ValueObjects.Temperature Temperature, Localization Localization); 
}
