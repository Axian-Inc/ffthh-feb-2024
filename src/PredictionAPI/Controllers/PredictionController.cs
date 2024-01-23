using FfthhFeb2024.TaxiFareRegression.DataStructures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using RegreFfthhFeb2024.TaxiFareRegression.DataStructures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FfthhFeb2024.PredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private PredictionEnginePool<TaxiTrip, TaxiTripFarePrediction> predictionEngine;

        public PredictionController(PredictionEnginePool<TaxiTrip, TaxiTripFarePrediction> predictionEnginePool)
        {
            this.predictionEngine = predictionEnginePool;
        }

        // POST api/<PredictionController>
        [HttpPost]
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

            var output = predictionEngine.Predict(modelName: "TaxiFareModel", modelInput);

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
}
