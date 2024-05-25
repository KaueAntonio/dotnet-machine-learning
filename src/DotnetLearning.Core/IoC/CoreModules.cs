using DotnetLearning.Core.FileOperations.Interfaces;
using DotnetLearning.Core.FileOperations.Services;
using DotnetLearning.Core.ImageClassification.Interfaces;
using DotnetLearning.Core.ImageClassification.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetLearning.Core.IoC
{
    public static class CoreModules
    {
        public static void AddCoreModules(IServiceCollection services)
        {
            #region
            services.AddScoped<IDataViewService, DataViewService>();
            services.AddScoped<IImageConsumptionService, ImageConsumptionService>();
            services.AddScoped<IImageTrainingService, ImageTrainingService>();
            #endregion

            #region
            services.AddScoped<IFileManagerService, FileManagerService>();
            services.AddScoped<IFileReaderService, FileReaderService>();
            services.AddScoped<IFileWriterService, FileWriterService>();
            #endregion

            #region
            services.AddScoped<MLContext, MLContext>();
            #endregion
        }
    }
}
