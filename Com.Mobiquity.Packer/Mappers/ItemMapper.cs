using Com.Mobiquity.Packer.Models;
using System;

namespace Com.Mobiquity.Packer.Mappers
{
    static class ItemMapper
    {
        /// <summary>
        /// Parses Item informations from string. Example input : (6,46.34,€48)
        /// </summary>
        /// <param name="data">string => Item informations</param>
        /// <returns>Item => new instance of Item class</returns>
        /// <example>(6,46.34,€48)</example>
        public static Item MapToItem(this string data)
        {
            var itemInformations = data.Remove(data.Length - 1).Remove(0, 1).Split(',');

            if (!int.TryParse(itemInformations[0], out var index))
                throw new ArgumentException(nameof(index));

            if (!float.TryParse(itemInformations[1], out var weight))
                throw new ArgumentException(nameof(weight));

            if (!int.TryParse(itemInformations[2].Remove(0, 1), out var cost))
                throw new ArgumentException(nameof(cost));

            return new Item(index, weight, cost);
        }
    }
}
