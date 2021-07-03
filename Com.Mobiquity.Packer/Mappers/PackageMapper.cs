using Com.Mobiquity.Packer.Models;
using System;
using System.Linq;

namespace Com.Mobiquity.Packer.Mappers
{
    static class PackageMapper
    {
        public static Package MapToPackage(this string data)
        {
            var packageInformations = data.Split(':');
            if (!int.TryParse(packageInformations[0].Trim(), out var packageCapacity))
                throw new ArgumentException();

            var itemInformations = packageInformations[1].Trim().Split(' ');

            return new Package(packageCapacity, itemInformations.Select(item => item.MapToItem()).ToArray());
        }

        public static string MapToString(this Package data)
        {
            return "";
        }
    }
}
