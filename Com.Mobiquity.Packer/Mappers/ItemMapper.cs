using Com.Mobiquity.Packer.Models;
using System;

namespace Com.Mobiquity.Packer.Mappers
{
    static class ItemMapper
    {
        public static Item MapToItem(this string data)
        {
            var itemInformations = data.Remove(0).Remove(data.Length - 1).Split(',');

            if (int.TryParse(itemInformations[0], out var index))
                throw new ArgumentException(nameof(index));

            if (float.TryParse(itemInformations[1], out var weight))
                throw new ArgumentException(nameof(weight));

            if (int.TryParse(itemInformations[2], out var cost))
                throw new ArgumentException(nameof(cost));

            return new Item(index, weight, cost);
        }

        public static string MapToString(this Item item)
        {
            return "";
        }
    }
}
