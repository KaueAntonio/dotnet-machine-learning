using DotnetLearning.Core.FileOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetLearning.Core.FileOperations.Interfaces
{
    public interface IFileManagerService
    {
        void Create(List<ImageTraningModel> images, int sizePart, int maxSize);
        void SeparateAndSaveFile(string path, string format);
    }
}
