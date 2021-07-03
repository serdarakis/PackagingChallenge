using Com.Mobiquity.Packer.Models;
using System;
using System.Linq;

namespace Com.Mobiquity.Packer.Mappers
{
    static class PackageMapper
    {
        /// <summary>
        /// Parses Package informations from string. Example input : 81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)
        /// </summary>
        /// <param name="data">string => Package informations</param>
        /// <returns>Item => new instance of Package class</returns>
        /// <example>81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)</example>
        public static Package MapToPackage(this string data)
        {
            var packageInformations = data.Split(':');
            if (!int.TryParse(packageInformations[0].Trim(), out var packageCapacity))
                throw new ArgumentException();

            //Split string by space gives us item information with parentheses. Item mapper will handle the rest
            var itemInformations = packageInformations[1].Trim().Split(' ');

            return new Package(packageCapacity, itemInformations.Select(item => item.MapToItem()).ToArray());
        }
    }
}
