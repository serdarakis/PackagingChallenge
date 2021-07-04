using Com.Mobiquity.Packer.Mappers;
using Com.Mobiquity.Packer.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Mobiquity.Packer
{
    public static class Packer
    {
        private static readonly IFileService _fileService = new FileService();
        private static readonly IPackerService _packerService = new PackerService();

        /// <summary>
        /// Reads given file and parses each line. Returns optimized item indexes in each line. 
        /// In case file is not able to parse (because of file does not exist or has an invalid format) or If any constraints are not meet, 
        /// throws ApiException.
        /// </summary>
        /// <param name="filePath">string -> file path</param>
        /// <exception cref="ApiException"></exception>
        /// <returns>string -> item indexes</returns>
        public static string Pack(string filePath)
        {
            if (!_fileService.Exists(filePath))
                throw new ApiException($"File {filePath} is not exists");

            var lines = _fileService.ReadAllLines(filePath);

            try
            {
                var optimizedLines = Optimize(lines);
                return string.Join(Environment.NewLine, optimizedLines);
            }
            catch (ArgumentException e)
            {
                throw new ApiException($"Input format is not acceptable. See inner exception.", e);
            }
            catch (Exception e)
            {
                throw new ApiException($"Unhandled exception occurred. See inner exception.", e);
            }
        }

        private static IEnumerable<string> Optimize(string[] lines)
        {
            foreach (var line in lines)
            {
                var itemIndexes = _packerService.Optimize(line.MapToPackage()).Select(item => item.Index);
                yield return itemIndexes.Any() ? string.Join(',', itemIndexes): "-";
            }
        }
    }


}
