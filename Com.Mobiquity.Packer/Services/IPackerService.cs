using Com.Mobiquity.Packer.Models;
using System;
using System.Collections;
using System.Linq;

namespace Com.Mobiquity.Packer.Services
{
    interface IPackerService
    {
        /// <summary>
        /// Processes package information and returns item array within package capacity to reach maximum cost.
        /// </summary>
        /// <param name="package">Com.Mobiquity.Packer.Models.Package -> Package information to optimization</param>
        /// <returns>Item[] -> Returns Items to Packed</returns>
        Item[] Optimize(Package package);
    }
    class PackerService : IPackerService
    {
        Item[] IPackerService.Optimize(Package package)
        {
            var result = GetOptimizedItems(new Hashtable(), package.Items, package.PackageCapacity, 0, Array.Empty<Item>());
            return result;
        }

        /// <summary>
        /// Since optimization is close to Knapsack problem. Similar algorithm is used to solve problem. 
        /// However, since items weights are not integers, Memorization approach was the best solution. 
        /// However, small adjustment needs to be done because index is integer and capacity was fractional number. 
        /// Hash table has been used instead of a memory array.
        /// </summary>
        private Item[] GetOptimizedItems(Hashtable memory, Item[] items, float capacity, int currentIndex, Item[] test)
        {
            if (capacity <= 0 || currentIndex >= items.Length)
                return test;

            var hashKey = $"{currentIndex}-{capacity}";

            // if similar problem have already been solved a, return the result from memory
            //since capacity is float
            if (memory.ContainsKey(hashKey))
            {
                return (Item[])memory[hashKey];
            }

            Item[] currentItemAdded = null;
            //Check if the item is within the maximum capacity
            //If item is within capacity limit, call "GetOptimizedItems" again with current item inserted to results and decrease remaining capacity.
            //If it is not, skips current item
            if (items[currentIndex].Weight <= capacity)
                currentItemAdded = GetOptimizedItems(memory, items,
                        (float)Math.Round(capacity - items[currentIndex].Weight, 2), currentIndex + 1, CopyWith(test, items[currentIndex]));

            // recursive call after excluding the element at the currentIndex
            var currentItemSkipped = GetOptimizedItems(memory, items, capacity, currentIndex + 1, test);

            //Checks which path has a higher cost (Current item is added or skipped). Returns path with higher cost
            if (currentItemAdded != null && currentItemAdded.Sum(item => item.Cost) > currentItemSkipped.Sum(item => item.Cost))
                memory[hashKey] = currentItemAdded;
            else
                memory[hashKey] = currentItemSkipped;

            return (Item[])memory[hashKey];
        }

        private Item[] CopyWith(Item[] items, Item data)
        {
            var retItems = new Item[items.Length + 1];
            items.CopyTo(retItems, 0);
            retItems[^1] = data;
            return retItems;
        }
    }
}
