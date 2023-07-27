﻿using PackIT.CommonAbstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name) : ICommand;
}
