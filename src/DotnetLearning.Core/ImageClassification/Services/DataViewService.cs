using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Models;
using DotnetLearning.Core.ImageClassification.Interfaces;
using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Services
{
    public class DataViewService(IFileReaderService fileReaderService, MLContext context) : IDataViewService
    {
        private readonly IFileReaderService _fileReaderService = fileReaderService;
        private readonly MLContext _context = context;

        public IDataView LoadDataFromImages(string path, string format)
        {
            IEnumerable<string> files = _fileReaderService.ReadImageFile(path, format);

            IEnumerable<ImageTraningModel> images = files.Select(image => new ImageTraningModel
            {
                ImageSource = File.ReadAllBytes(image),
                Label = Path.GetFileName(Path.GetDirectoryName(image))
            });

            return Load(images);
        }

        public IDataView LoadDataFromCsv(string path)
        {
            IEnumerable<ImageTraningModel> images = _fileReaderService.ReadCsvFile(path);

            return Load(images);
        }

        private IDataView Load(IEnumerable<ImageTraningModel> images)
        {
            IDataView data = _context.Data.LoadFromEnumerable(images);

            return data;
        }
    }
}
