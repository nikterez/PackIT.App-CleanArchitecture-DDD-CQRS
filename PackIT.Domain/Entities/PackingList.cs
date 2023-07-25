﻿using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Entities
{
    public class PackingList
    {
        public Guid Id { get; private set; }
        private PackingListName _name;
        private Localization _localization;
        private readonly LinkedList<PackingItem> _items = new();

        internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        {
            Id = id;
            _name = name;
            _localization = localization;

        }

        public void AddItem(PackingItem item) 
        {
            var itemExists = _items.Any(i => i.Equals(item));

            if (itemExists) 
            {
                throw new PackingItemAlreadyExistsException(_name, item.Name);
            }

            _items.AddLast(item);
        }
    }
}
