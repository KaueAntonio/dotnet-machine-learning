using Microsoft.ML.Data;

namespace DotnetLearning.Core.FileOperations.Models
{
    public class ImageTraningModel
    {
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }
    }
}
