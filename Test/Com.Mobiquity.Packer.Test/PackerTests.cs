using System;
using System.IO;
using System.Linq;
using Xunit;
using static Com.Mobiquity.Packer.Test.PackerTestsHarness;

namespace Com.Mobiquity.Packer.Test
{
    public class PackerTests : IDisposable
    {
        [Fact]
        public void MissingFile_ShouldThrowsApiException()
        {
            var exception = Record.Exception(() => Packer.Pack(MissingFilePath));

            Assert.IsType<ApiException>(exception);
        }

        [Fact]
        public void PacketWithHeavierThanMaxWeight_ShouldThrowsApiException()
        {
            var path = CreateFileWithData(new string[] { InputWithPacketHeavierThanMaxWeight });

            var exception = Record.Exception(() => Packer.Pack(path));

            Assert.IsType<ApiException>(exception);
        }

        [Fact]
        public void ItemWithHeavierThanMaxWeight_ShouldThrowsApiException()
        {
            var path = CreateFileWithData(new string[] { InputWithOverWeightItem });

            var exception = Record.Exception(() => Packer.Pack(path));

            Assert.IsType<ApiException>(exception);
        }

        [Fact]
        public void InputWithMoreItemThenMaxSupportedItemCount_ShouldThrowsApiException()
        {
            var path = CreateFileWithData(new string [] { InputWithMoreItemThenMaxSupportedItemCount });

            var exception = Record.Exception(() => Packer.Pack(path));

            Assert.IsType<ApiException>(exception);
        }

        [Fact]
        public void ValidInputs_ShouldReturnExpectedResults()
        {
            var path = CreateFileWithData(ValidInputs);

            var output = Packer.Pack(path);
            var results = output.Split(Environment.NewLine);

            Assert.Equal(ValidResults, results);
        }

        void IDisposable.Dispose()
        {
            DeleteFileIfExists();
        }
    }

    internal static class PackerTestsHarness
    {
        private const float MaxWeight = 100;
        private const int MaxSupportedItemCount = 15;

        internal const string MissingFilePath = "ThisFileDoesNotExsist";

        internal static string InputWithPacketHeavierThanMaxWeight = $"{MaxWeight + 1f} : (1,15.3,€34)";
        internal static string InputWithOverWeightItem = $"81 : (1,53.38,€45) (2,{MaxWeight + 1f},€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)";
        internal static string InputWithMoreItemThenMaxSupportedItemCount = $"81 : { string.Join(' ', Enumerable.Repeat("(3, 78.48,€3)", MaxSupportedItemCount + 1))})";
        internal static string[] ValidInputs =
        {
            "81 : (1,53.38,€45) (2,88.62,€98) (3,78.48,€3) (4,72.30,€76) (5,30.18,€9) (6,46.34,€48)",
            " 8 : (1,15.3,€34)",
            "75 : (1,85.31,€29) (2,14.55,€74) (3,3.98,€16) (4,26.24,€55) (5,63.69,€52) (6,76.25,€75) (7,60.02,€74) (8,93.18,€35) (9,89.95,€78)",
            "56 : (1,90.72,€13) (2,33.80,€40) (3,43.15,€10) (4,37.97,€16) (5,46.81,€36) (6,48.77,€79) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)",
            "54 : (1,33.80,€40) (2,43.15,€10) (3,37.97,€16) (4,30.18,€9) (5,46.34,€48)",
            "25 : (1,15.3,€34) (2,42.80,€40) (3,1.15,€10) (4,25.97,€16)",
            "42 : (1,14.55,€74) (2,3.98,€16) (3,63.69,€52) (4,93.18,€35) (5,89.95,€78)",
            "1 : (1,90.72,€13)  (5,46.81,€36) (7,81.80,€45) (8,19.36,€79) (9,6.76,€64)"
        };
        internal static string[] ValidResults =
        {
            "4",
            "-",
            "2,7",
            "8,9",
            "5",
             "1,3",
            "1,2",
            "-"
        };

        internal static string CreateFileWithData(string[] data, string path = "", string fileName = "example")
        {
            var combinedPath = Path.Combine(path, fileName);

            File.WriteAllLines(combinedPath, data.Select(str => str.Trim()));

            return combinedPath;
        }

        internal static void DeleteFileIfExists(string path = "", string fileName = "example")
        {
            var combinedPath = Path.Combine(path, fileName);

            if (File.Exists(combinedPath))
                File.Delete(combinedPath);
        }
    }
}
