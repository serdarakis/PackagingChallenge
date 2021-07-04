using System.IO;

namespace Com.Mobiquity.Packer.Services
{
    class FileService : IFileService
    {
        bool IFileService.Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ApiException($"{nameof(path)} can not be empty");
            }

            return File.Exists(path);
        }

        string[] IFileService.ReadAllLines(string path)
        {
            var lines = File.ReadAllLines(path, System.Text.Encoding.UTF8);
            return lines;
        }
    }
}
