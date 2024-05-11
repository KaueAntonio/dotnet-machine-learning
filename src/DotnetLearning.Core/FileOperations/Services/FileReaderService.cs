using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Models;

namespace DotnetLearning.Core.FileOperations.Services
{
    public class FileReaderService : IFileReaderService
    {
        public FileReaderService() { }

        public IEnumerable<string> ReadImageFile(string filePath, string fileFormat)
        {
            IEnumerable<string> images = Directory.GetFiles(filePath, "*.*", SearchOption.AllDirectories)
               .Where(file => file.EndsWith(fileFormat))
               .ToList();

            return images;
        }

        public IEnumerable<ImageTraningModel> ReadCsvFile(string filePath)
        {
            IEnumerable<string> files = Directory.GetFiles(filePath, "*.csv", SearchOption.AllDirectories)
                .ToList();

            List<ImageTraningModel> images = new();

            foreach (var file in files)
            {
                using StreamReader reader = new(file);

                string line;
                while ((line = reader.ReadLine()) is not null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string image = parts[0].Trim();
                        string name = parts[1].Trim();

                        byte[] byteImage = Convert.FromBase64String(image);

                        images.Add(new ImageTraningModel
                        {
                            ImageSource = byteImage,
                            Label = name
                        });
                    }
                }
            }

            return images;
        }
    }
}
