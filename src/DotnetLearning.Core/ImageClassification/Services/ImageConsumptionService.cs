using DotnetLearning.Core.FileOperations.Models;
using DotnetLearning.Core.ImageClassification.Interfaces;
using DotnetLearning.Core.ImageClassification.Models;
using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Services
{
    public class ImageConsumptionService(MLContext context) : IImageConsumptionService
    {
        private readonly MLContext _context = context;

        public PredictionModel Predict(ImageTraningModel input)
        {
            Lazy<PredictionEngine<ImageTraningModel, PredictionModel>> PredictEngine = new(() => CreatePredictEngine("Models/training-docs.mdl"), true);

            PredictionEngine<ImageTraningModel, PredictionModel> predEngine = PredictEngine.Value;

            return predEngine.Predict(input);
        }

        private PredictionEngine<ImageTraningModel, PredictionModel> CreatePredictEngine(string modelPath)
        {
            ITransformer mlModel = _context.Model.Load(modelPath, out _);

            return _context.Model.CreatePredictionEngine<ImageTraningModel, PredictionModel>(mlModel);
        }
    }
}
