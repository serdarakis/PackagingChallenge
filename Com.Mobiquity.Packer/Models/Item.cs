using Com.Mobiquity.Packer.Constants;
using System;

namespace Com.Mobiquity.Packer.Models
{
    class Item
    {
        public readonly int Index;
        public readonly float Weight;
        public readonly int Cost;

        public Item(int index, float weight, int cost)
        {
            if (weight > Constraints.ItemMaxWeight)
                throw new ArgumentException($"Item weight can not be more than {Constraints.ItemMaxWeight}.", nameof(weight));

            Index = index;
            Weight = weight;
            Cost = cost;
        }
    }
}
