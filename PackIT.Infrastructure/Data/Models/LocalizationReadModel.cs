﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Data.Models
{
    internal class LocalizationReadModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public static LocalizationReadModel Create(string value)
        {
            var splitLocalization = value.Split(',');

            return new LocalizationReadModel 
            {
                City = splitLocalization.First(), 
                Country = splitLocalization.Last()
            };
        }

        public override string? ToString() => $"{City},{Country}";

    }

}
