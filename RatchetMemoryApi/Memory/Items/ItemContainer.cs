using RatchetMemoryApi.Memory.Addresses;
using System;
using System.Collections.Generic;

namespace RatchetMemoryApi.Memory.Items
{
    public class ItemContainer
    {
        public static List<ItemBase> Items = new List<ItemBase>();

        static ItemContainer()
        {

            foreach(var itemEnum in Enum.GetValues(typeof(ItemToggles)))
            {
                Items.Add(new ItemBase() 
                { 
                    EnabledAddress = (int)itemEnum,
                    Name = itemEnum.ToString(),
                });
            }

            var gadgets = Enum.GetValues(typeof(Gadgets));

            foreach (var gadgetEnum in gadgets)
            {
                Items.Add(new ItemBase()
                {
                    EnabledAddress = (int)gadgetEnum,
                    Name = gadgetEnum.ToString(),
                });
            }
        }
    }
}
