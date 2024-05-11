using DotnetLearning.Core.FileOperations.Models;

namespace DotnetLearning.Core.FileOperations.Interfaces
{
    public interface IFileWriterService
    {
        void SaveFile(string path, string format, List<ImageTraningModel> images);
    }
}
