using System.IO;

namespace Com.Mobiquity.Packer.Services
{
    interface IFileService
    {
        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">string -> The file to check.</param>
        /// <returns>
        /// true: if the caller has the required permissions and path contains the name of an existing file; false: otherwise.
        /// </returns>
        /// <exception cref="ApiException"></exception>
        bool Exists(string path);

        /// <summary>
        /// Opens a text file, reads all lines of the file into a string array, and then closes the file.
        /// </summary>
        /// <param name="path">string -> Path to a file</param>
        /// <returns>string[] -> Returns an array of lines. Returns empty array if the file is empty</returns>
        string[] ReadAllLines(string path);
    }

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
