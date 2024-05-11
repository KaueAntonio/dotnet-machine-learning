namespace DotnetLearning.Core.ImageClassification.Interfaces
{
    public interface IImageTrainingService
    {
        void CreateTrainingProvider(string trainingPath, string sourcePath, string sourceFormat);
        void StartTraining(string name);
    }
}
