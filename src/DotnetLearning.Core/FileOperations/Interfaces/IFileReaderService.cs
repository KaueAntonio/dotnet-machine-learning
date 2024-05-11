using DotnetLearning.Core.FileOperations.Models;

namespace DotnetLearning.Core.FileOperations.Interfaces
{
    public interface IFileReaderService
    {
        IEnumerable<string> ReadImageFile(string path, string format);
        IEnumerable<ImageTraningModel> ReadCsvFile(string filePath);
    }
}
