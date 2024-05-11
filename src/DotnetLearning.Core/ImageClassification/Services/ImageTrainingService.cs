using DotnetLearning.Core.ImageClassification.Interfaces;
using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Services
{
    public class ImageTrainingService
    {
        private string _trainingPath;
        private string _sourcePath;
        private string _sourceFormat;

        private readonly IDataViewService _dataViewService;

        public ImageTrainingService(IDataViewService dataViewService) 
        {
            _dataViewService = dataViewService;
        }

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

            MLContext context = new();

            IDataView data = _dataViewService.LoadDataFromImages(_sourcePath, _sourceFormat);

            TrainingData(context, data, name);
        }

        private void TrainingData(MLContext context, IDataView data, string name)
        {
            ITransformer model = TrainPipeline(context, data);

            context.Model.Save(model, data.Schema, $"{_trainingPath}\\{name}.mdl");
        }

        private static ITransformer TrainPipeline(MLContext mlContext, IDataView trainData)
        {
            IEstimator<ITransformer> pipeline = BuildPipeline(mlContext);

            ITransformer model = pipeline.Fit(trainData);

            return model;
        }

        private static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            IEstimator<ITransformer> pipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: @"Label", inputColumnName: @"Label")
                                    .Append(mlContext.MulticlassClassification.Trainers.ImageClassification(labelColumnName: @"Label", scoreColumnName: @"Score", featureColumnName: @"ImageSource"))
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: @"PredictedLabel", inputColumnName: @"PredictedLabel"));

            return pipeline;
        }
    }
}
