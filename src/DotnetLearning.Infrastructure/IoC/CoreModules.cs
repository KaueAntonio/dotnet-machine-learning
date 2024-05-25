using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Services;
using DotnetLearning.Core.ImageClassification.Interfaces;
using DotnetLearning.Core.ImageClassification.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;

namespace DotnetLearning.Infrastructure.IoC
{
    public static class CoreModules
    {
        public static void AddCoreModules(IServiceCollection builder)
        {
            #region ImageClassification
            builder.AddScoped<IDataViewService, DataViewService>();
            builder.AddScoped<IImageConsumptionService, ImageConsumptionService>();
            builder.AddScoped<IImageTrainingService, ImageTrainingService>();
            builder.AddScoped<MLContext, MLContext>();
            #endregion

            #region FileOperations
            builder.AddScoped<IFileManagerService, FileManagerService>();
            builder.AddScoped<IFileReaderService, FileReaderService>();
            builder.AddScoped<IFileWriterService, FileWriterService>();
            #endregion
        }
    }
}