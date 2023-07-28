using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Common.Options
{
    public static class Extensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration config, string sectionName) where TOptions : new()
        {
            var options = new TOptions();
            config.GetSection(sectionName).Bind(options);

            return options;
        }
    }
}
