using Microsoft.ML.Data;

namespace RegreFfthhFeb2024.TaxiFareRegression.DataStructures
{
    public class TaxiTripFarePrediction
    {
        [ColumnName("Score")]
        public float FareAmount { get; set; }
    }
}