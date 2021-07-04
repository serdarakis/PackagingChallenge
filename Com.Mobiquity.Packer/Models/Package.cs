using Com.Mobiquity.Packer.Constants;
using System;

namespace Com.Mobiquity.Packer.Models
{
    class Package
    {
        public readonly int PackageCapacity;

        public readonly Item[] Items;

        public Package(int packageCapacity, Item[] items)
        {
            if (packageCapacity > Constraints.PackageMaxWeight)
                throw new ArgumentException($"Package weight can not be more than {Constraints.PackageMaxWeight}.", nameof(packageCapacity));
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length > Constraints.PackageMaxNumberOfItems)
                throw new ArgumentOutOfRangeException($"Items can not be more than {Constraints.PackageMaxNumberOfItems}", nameof(items));

            PackageCapacity = packageCapacity;
            Items = items;
        }
    }
}
