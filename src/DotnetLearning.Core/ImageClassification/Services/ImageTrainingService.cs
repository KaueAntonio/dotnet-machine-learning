using DotnetLearning.Core.ImageClassification.Interfaces;
using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Services
{
    public class ImageTrainingService(IDataViewService dataViewService, MLContext context) : IImageTrainingService
    {
        private string _trainingPath;
        private string _sourcePath;
        private string _sourceFormat;
        private readonly MLContext _context = context;
        private readonly IDataViewService _dataViewService = dataViewService;

        public void CreateTrainingProvider(string trainingPath, string sourcePath, string sourceFormat)
        {
            _sourceFormat = sourceFormat;
            _sourcePath = sourcePath;
            _trainingPath = trainingPath;
        }

        public void StartTraining(string name)
        {
            if (_trainingPath == String.Empty)
                throw new Exception("Crie o provider antes para poder treinar");

            IDataView data = _dataViewService.LoadDataFromImages(_sourcePath, _sourceFormat);

            TrainingData(data, name);
        }

        private void TrainingData(IDataView data, string name)
        {
            ITransformer model = TrainPipeline(data);

            _context.Model.Save(model, data.Schema, $"{_trainingPath}\\{name}.mdl");
        }

        private ITransformer TrainPipeline(IDataView trainData)
        {
            IEstimator<ITransformer> pipeline = BuildPipeline();

            ITransformer model = pipeline.Fit(trainData);

            return model;
        }

        private IEstimator<ITransformer> BuildPipeline()
        {
            IEstimator<ITransformer> pipeline = _context.Transforms.Conversion.MapValueToKey(outputColumnName: @"Label", inputColumnName: @"Label")
                                    .Append(_context.MulticlassClassification.Trainers.ImageClassification(labelColumnName: @"Label", scoreColumnName: @"Score", featureColumnName: @"ImageSource"))
                                    .Append(_context.Transforms.Conversion.MapKeyToValue(outputColumnName: @"PredictedLabel", inputColumnName: @"PredictedLabel"));

            return pipeline;
        }
    }
}
