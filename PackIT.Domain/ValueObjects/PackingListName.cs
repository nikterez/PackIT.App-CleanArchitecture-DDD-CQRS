﻿using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string value)
        {
            Value = string.IsNullOrEmpty(value) ? throw new EmptyPackingListNameException() : value;
        }

        public static implicit operator PackingListName(string name) => new(name);

        public static implicit operator string(PackingListName name) => name.Value;
    }
}
