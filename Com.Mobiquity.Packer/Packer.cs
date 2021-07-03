using Com.Mobiquity.Packer.Services;

namespace Com.Mobiquity.Packer
{
    public static class Packer
    {
        private static IFileService _fileService = new FileService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="ApiException"></exception>
        /// <returns></returns>
        public static string Pack(string filePath)
        {
            if (!_fileService.Exists(filePath))
                throw new ApiException($"File {filePath} is not exists");

            return "";
        }
    }

  
}
