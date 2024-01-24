# FFTHH Feb 2024
## Machine Learning (Supervised) with ML.NET and .NET Core Web API
This project is code intended to pair with the following FFTHH sessions:
* [January - Getting Started, AI/ML (Supervised Learning) - Part A](https://axianinc.atlassian.net/wiki/spaces/AXLND/pages/2845114386/January+-+Getting+Started+AI+ML+Supervised+Learning+-+Part+A)
* [February (Jan 25th) - Supervised Learning (Testing and MLOps) - Part B](https://axianinc.atlassian.net/wiki/spaces/AXLND/pages/2879848449/February+Jan+25th+-+Supervised+Learning+-+Part+B)

This public repository remixes examples from the [ML.NET Machine Learning Samples Repository](https://github.com/dotnet/machinelearning-samples/tree/main) to demostrate how ML.NET brings together:
* Data Prep/Featurization (e.g. normalization, encoding categories)
* Training/Testing Models
* Saving trained models to disk
* Loading a trained model, and exposing access via API

## Getting Started
This project makes use of .NET 8, ML.NET, and one of Visual Studio, or Visual Studio Code to run. The following will need to be installed on your workstation for the code to compile/run.

- [.NET v8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [ML.NET](https://github.com/dotnet/docs/blob/main/docs/machine-learning/how-to-guides/install-ml-net-cli.md)
- One of the IDEs below:
    - [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/)
    - [Visual Studio Code](https://code.visualstudio.com/download)


## Running Locally
1. Clone down this repository.
1. Open up the folder in (VS Code) or Solution File (Visual Studio) located at `./src/ffthh-feb-2024.sln`
1. Run the TaxiFareRegression project (Console App) as a console app or with the debugger. A `TaxiFareModel.zip` should materialize under `./trained-models/TaxiFareModel.zip`
1. Run the X project as a console app or with the debugger. A `ModelName.zip` should materialize under `./trained-models/TaxiFareModel.zip`
1. Run the PredictionAPI project and use the swagger published at `https://localhost:7072/swagger/index.html` to make predictions.
__Example:__ Taxi Fare Prediction (tripTime is in seconds, tripDistance is in miles)
```
POST /api/Prediction
{
  "passengerCount": 2,
  "tripTime": 935,
  "tripDistance": 9.6
}
Response
{
  "fareAmount": 24.927794
}
```
__Example Next:__ Taxi Fare Prediction (tripTime is in seconds, tripDistance is in miles)
```
POST /api/Prediction
{
  "passengerCount": 2,
  "tripTime": 935,
  "tripDistance": 9.6
}
Response
{
  "fareAmount": 24.927794
}
```