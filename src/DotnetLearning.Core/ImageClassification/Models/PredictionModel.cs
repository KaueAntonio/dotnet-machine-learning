using Microsoft.ML.Data;

namespace DotnetLearning.Core.ImageClassification.Models
{
    public class PredictionModel
    {
        [ColumnName(@"Label")]
        public uint Label { get; set; }

        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }

        [ColumnName(@"PredictedLabel")]
        public string PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }

        public override string ToString()
        {
            return @$"Foi identificado na foto um objeto {this.PredictedLabel} com uma eficácia de {(this.Score[0] * 100).ToString("0.00")}%";
        }
    }
}
