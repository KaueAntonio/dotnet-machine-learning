using DotnetLearning.Core.FileOperations.Models;
using DotnetLearning.Core.ImageClassification.Models;

namespace DotnetLearning.Core.ImageClassification.Interfaces
{
    public interface IImageConsumptionService
    {
        PredictionModel Predict(ImageTraningModel input, string modelPath);
    }
}
