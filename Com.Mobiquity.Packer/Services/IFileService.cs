using System.IO;

namespace Com.Mobiquity.Packer.Services
{
    interface IFileService
    {
        bool Exists(string path);
    }

    class FileService : IFileService
    {
        bool IFileService.Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
