using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Models;

namespace DotnetLearning.Core.FileOperations.Services
{
    public class FileManagerService
    {
        private readonly IFileWriterService _fileWriterService1;

        private int _maxSize;
        private int _size;
        private int _parts;
        private int _maxSizeParts;
        private int _remainder;
        private List<ImageTraningModel> _images;

        public FileManagerService(IFileWriterService fileWriterService) 
        {
            _fileWriterService1 = fileWriterService;
        }

        public void Create(List<ImageTraningModel> images, int sizePart, int maxSize)
        {
            _maxSize = maxSize;
            _maxSizeParts = sizePart;
            _images = images;
            _size = images.Count;
            _parts = _size / _maxSize;
            _remainder = _size % _maxSize;
        }

        public void SeparateAndSaveFile(string path, string format)
        {
            ImageTraningModel[] images = _images.ToArray();

            for(int i = 0; i < _parts; i ++)
            {
                ImageTraningModel[] part = new ImageTraningModel[_maxSize];

                Array.Copy(images, i * _maxSize, part, 0, _maxSizeParts);

                List<ImageTraningModel> imagesForSave = part.ToList();

                _fileWriterService1.SaveFile(path, format, imagesForSave);
            }

            if (_remainder > 0)
            {
                ImageTraningModel[] part = new ImageTraningModel[_maxSize];

                Array.Copy(images, _parts * _remainder, part, 0, _remainder);

                List<ImageTraningModel> imagesForSave = part.ToList();

                _fileWriterService1.SaveFile(path, format, imagesForSave);
            }
        }
    }
}
