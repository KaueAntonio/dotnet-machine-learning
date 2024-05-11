using Microsoft.ML;

namespace DotnetLearning.Core.ImageClassification.Interfaces
{
    public interface IDataViewService
    {
        IDataView LoadDataFromImages(string path, string format);
        IDataView LoadDataFromCsv(string path);
    }
}
