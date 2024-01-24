
using FfthhFeb2024.IrisMulticlassClassification.DataStructures;
using FfthhFeb2024.TaxiFareRegression.DataStructures;
using Microsoft.Extensions.ML;

namespace FfthhFeb2024.PredictionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DI for predictive models (should be static) and enable hot reloading.
            var taxiModelPath = "../../../../../trained-models/TaxiFareModel.zip";
            var taxiAbsolutePath = GetAbsolutePath(taxiModelPath);
            builder.Services.AddPredictionEnginePool<TaxiTrip, TaxiTripFarePrediction>()
                .FromFile(modelName: "TaxiFareModel", filePath: taxiAbsolutePath, watchForChanges: true);

            var irisModelPath = "../../../../../trained-models/IrisClassificationModel.zip";
            var irisAbsolutePath = GetAbsolutePath(irisModelPath);
            builder.Services.AddPredictionEnginePool<IrisData, IrisPrediction>()
                .FromFile(modelName: "IrisClassificationModel", filePath: irisAbsolutePath, watchForChanges: true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);

            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
