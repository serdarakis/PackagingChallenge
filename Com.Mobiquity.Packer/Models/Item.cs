namespace Com.Mobiquity.Packer.Models
{
    class Item
    {
        public readonly int Index;
        public readonly float Weight;
        public readonly int Cost;

        public Item(int index, float weight, int cost)
        {
            Index = index;
            Weight = weight;
            Cost = cost;
        }
    }
}
