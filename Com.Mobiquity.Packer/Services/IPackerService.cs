using Com.Mobiquity.Packer.Models;

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
}
