using Microsoft.ML.Data;

namespace FfthhFeb2024.TaxiFareRegression.DataStructures
{
    public class TaxiTripFarePrediction
    {
        [ColumnName("Score")]
        public float FareAmount { get; set; }
    }
}