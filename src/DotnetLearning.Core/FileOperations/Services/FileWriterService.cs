using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Models;

namespace DotnetLearning.Core.FileOperations.Services
{
    public class FileWriterService() : IFileWriterService
    {
        public void SaveFile(string path, string format, List<ImageTraningModel> images)
        {
            string fileName = $"{path}\\{Guid.NewGuid()}{format}";

            using FileStream fileStream = File.Create(fileName);
            using StreamWriter streamWriter = new(fileStream);

            foreach (var image in images)
            {
                string line = $"{Convert.ToBase64String(image.ImageSource)}, {image.Label}";
                streamWriter.WriteLine(line);
            }

            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
