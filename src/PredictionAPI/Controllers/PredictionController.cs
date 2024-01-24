using FfthhFeb2024.IrisMulticlassClassification.DataStructures;
using FfthhFeb2024.TaxiFareRegression.DataStructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using Microsoft.ML.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FfthhFeb2024.PredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private PredictionEnginePool<TaxiTrip, TaxiTripFarePrediction> taxiTripPredictionEngine;
        private PredictionEnginePool<IrisData, IrisPrediction> irisPredictionEngine;

        public PredictionController(
            PredictionEnginePool<TaxiTrip, TaxiTripFarePrediction> taxiPredictionEnginePool,
            PredictionEnginePool<IrisData, IrisPrediction> irisPredictionEnginePool)
        {
            this.taxiTripPredictionEngine = taxiPredictionEnginePool;
            this.irisPredictionEngine = irisPredictionEnginePool;
        }

        // POST api/<PredictionController>
        [HttpPost]
        [Route("api/[controller]/taxifare")]
        public TaxiTripFarePrediction Post([FromBody] TaxTripInput input)
        {
            var modelInput = new TaxiTrip()
            {
                VendorId = "CMT",
                RateCode = "1",
                PassengerCount = input.PassengerCount,
                TripTime = input.TripTime,
                TripDistance = input.TripDistance,
                PaymentType = "CRD",
            };

            var output = taxiTripPredictionEngine.Predict(modelName: "TaxiFareModel", modelInput);

            return output;
        }

        // POST api/<PredictionController>
        [Route("api/[controller]/iris")]
        [HttpPost]
        public IrisClassification Post([FromBody] IrisInput input)
        {
            var modelInput = new IrisData
            {
                SepalLength = input.SepalLength,
                SepalWidth = input.SepalWidth,
                PetalLength = input.PetalLength,
                PetalWidth = input.PetalWidth,
            };

            var prediction = irisPredictionEngine.Predict(modelName: "IrisClassificationModel", modelInput);

            var output = new IrisClassification
            {
                Setosa = prediction.Score[0],
                Versicolor = prediction.Score[1],
                Verginica = prediction.Score[2],
            };

            return output;
        }
    }

    public class TaxTripInput
    {
        /// <summary>
        /// Number of passengers in the taxi ride.
        /// </summary>
        public int PassengerCount { get; set; }

        /// <summary>
        /// Trip time in seconds.
        /// </summary>
        public int TripTime { get; set; }

        /// <summary>
        /// Trip distance in miles.
        /// </summary>
        public float TripDistance { get; set; }
    }

    public class IrisInput
    {
        /// <summary>
        /// Sepal Length in centimeteres
        /// </summary>
        public float SepalLength { get; set; }

        /// <summary>
        /// Sepal Width in centimeteres
        /// </summary>
        public float SepalWidth { get; set; }

        /// <summary>
        /// Petal Length in centimeteres
        /// </summary>
        public float PetalLength { get; set; }

        /// <summary>
        /// Petal Width in centimeteres
        /// </summary>
        public float PetalWidth { get; set; }
    }

    public class IrisClassification
    {
        public float Setosa { get; set; }
        public float Versicolor { get; set; }
        public float Verginica { get; set; }
    }
}
