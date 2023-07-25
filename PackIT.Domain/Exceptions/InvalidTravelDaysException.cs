﻿using PackIT.CommonAbstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTravelDaysException : PackItException
    {
        public ushort Days { get; }
        public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is invalid travel days.")
        {
            Days = days;
        }
    }
}
