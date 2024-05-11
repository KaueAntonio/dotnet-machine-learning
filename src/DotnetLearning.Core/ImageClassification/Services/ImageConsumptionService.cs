using DotnetLearning.Core.FileOperations.Models;
using DotnetLearning.Core.ImageClassification.Interfaces;
using DotnetLearning.Core.ImageClassification.Models;
using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Services
{
    public class ImageConsumptionService : IImageConsumptionService
    {
        public ImageConsumptionService() { }

        public PredictionModel Predict(ImageTraningModel input, string modelPath)
        {
            Lazy<PredictionEngine<ImageTraningModel, PredictionModel>> PredictEngine = new(() => CreatePredictEngine(modelPath), true);

            PredictionEngine<ImageTraningModel, PredictionModel> predEngine = PredictEngine.Value;

            return predEngine.Predict(input);
        }

        private static PredictionEngine<ImageTraningModel, PredictionModel> CreatePredictEngine(string modelPath)
        {
            MLContext mlContext = new();

            ITransformer mlModel = mlContext.Model.Load(modelPath, out _);

            return mlContext.Model.CreatePredictionEngine<ImageTraningModel, PredictionModel>(mlModel);
        }
    }
}
