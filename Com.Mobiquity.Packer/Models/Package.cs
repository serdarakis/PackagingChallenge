namespace Com.Mobiquity.Packer.Models
{
    class Package
    {
        public readonly int PackageCapacity;

        public readonly Item[] Items;

        public Package(int packageCapacity, Item[] items)
        {
            PackageCapacity = packageCapacity;
            Items = items;
        }
    }
}
