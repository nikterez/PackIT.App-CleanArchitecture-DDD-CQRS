﻿using PackIT.CommonAbstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get; }
        public PackingItemNotFoundException(string itemName) : base($"Packing item {itemName} not found in ")
        {
            ItemName = itemName;
        }
    }
}
