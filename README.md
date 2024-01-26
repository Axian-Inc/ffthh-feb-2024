# FFTHH Feb 2024
## Machine Learning (Supervised) with ML.NET and .NET Core Web API
This project is intended to pair with the following FFTHH sessions:
* [January - Getting Started, AI/ML (Supervised Learning) - Part A](https://axianinc.atlassian.net/wiki/spaces/AXLND/pages/2845114386/January+-+Getting+Started+AI+ML+Supervised+Learning+-+Part+A)
* [February (Jan 25th) - Supervised Learning (Testing and MLOps) - Part B](https://axianinc.atlassian.net/wiki/spaces/AXLND/pages/2879848449/February+Jan+25th+-+Supervised+Learning+-+Part+B)

This public repository remixes examples from the [ML.NET Machine Learning Samples Repository](https://github.com/dotnet/machinelearning-samples/tree/main) to demostrate how ML.NET brings together:
* Data Prep/Featurization (e.g. normalization, encoding categories)
* Training/Testing Models
* Saving trained models to disk
* Loading a trained model, and exposing access via API

## Getting Started
This project makes use of .NET 8, ML.NET, and one of Visual Studio, or Visual Studio Code to examine/explore code. The following will need to be installed on your workstation.

- [.NET v8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [ML.NET](https://github.com/dotnet/docs/blob/main/docs/machine-learning/how-to-guides/install-ml-net-cli.md)
- One of the IDEs below:
    - [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/)
    - [Visual Studio Code](https://code.visualstudio.com/download)

## Running Locally
1. Clone down this repository.
1. Open up the folder in (VS Code) or Solution File (Visual Studio) located at `./src/ffthh-feb-2024.sln`

### TaxiFare Regression
This project builds a regression model based off of taxi fare data provided by New York City. The data is housed at `{projectRoot}/data/` and has already been broken up into test and training sets.

The model is saved to `{projectRoot}/trained-models/TaxiFareModel.zip` and is needed by the `Prediction API` project to issue taxi fare predictions.

![Taxi fare meter](https://miro.medium.com/v2/resize:fit:600/1*m4Kv3w4-PnWDG4H4ObJZfw.png)

1. Run the TaxiFareRegression project (Console App) 
```
dotnet run --project ./src/TaxiFareRegression/
```
2. Testing statistics are displayed (e.g. R-Squared, RMS).
3. And a model is saved at `./trained-models/TaxiFareModel.zip`

### Iris Classification
This project builds a classification model based off of iris (flower) petal/sepal lengths/widths recorded in centimeters. The data is provided by kaggle.com and housed at `{projectRoot}/data/` and has already been broken up into test and training sets.

#### A Little Bit about Irises
An Iris is a flower that has several species. They're not always easy to identify (see below), but their petals and sepals have ratios of size that follow a pattern. This pattern is trained into a model using the data in this project.

![Examples of Versicolor, Setosa, and Virginica iris species](https://miro.medium.com/v2/resize:fit:540/0*Uw37vrrKzeEWahdB) 

![Example of how petal and sepal size ratios inform iris species identification](https://miro.medium.com/v2/resize:fit:540/0*7H_gF1KnslexnJ3s) 

#### Flower Defnitions
- **Sepal**: The outer parts of the flower (often green and leaf-like) that enclose a developing bud.
- **Petal**: The parts of a flower that are often conspicuously colored.
- **Stamen**: The pollen producing part of a flower, usually with a slender filament supporting the anther.

The model is saved to `{projectRoot}/trained-models/IrisClassificationModel.zip` and is needed by the `Prediction API` project to make iris classification predictions.

1. Run the TaxiFareRegression project (Console App) 
```
dotnet run --project ./src/IrisMulticlassClassification/
```
2. Testing statistics are displayed (e.g. LogLoss, FScore).
3. And a model is saved at `./trained-models/IrisClassificationModel.zip`

### Prediction API
This project depends on the prior two (`TaxiRegression` and `IrisMulticlassClassification`) projects having both been sucessfully run and models saved to the `./trained-models/` folder).

First verify that you have a valid .NET development certificate setup.
```
dotnet dev-certs https --check --trust
```

If you don't have a valid certificate. Run the following.
```
dotnet dev-certs https --trust
```

#### Launch and Query Prediction API
1. Launch the Prediction API using an IDE or via the command line.

```
dotnet run --project ./src/PredictionAPI/ --launch-profile https
```
2. Navigate a browser to https://localhost:7072/swagger/index.html
3. Use the swagger published to request predictions.
__Example:__ Taxi fare prediction (tripTime is in seconds, tripDistance is in miles)
```
POST /api/prediction/taxifare
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
__Example Next:__ Iris class prediction (all fields are in centimeters)
```
POST /api/prediction/iris
{
  "sepalLength": 4.1,
  "sepalWidth": 3.3,
  "petalLength": 1.6,
  "petalWidth": 0.2
}
Response
{
  "setosa": 0.9971434,
  "versicolor": 0.0028566187,
  "verginica": 0.00000000514
}
```

## Next
- Explore [ML.NET](https://dotnet.microsoft.com/en-us/learn/ml-dotnet/get-started-tutorial/intro)
- Look at more ML.NET examples of supervised learning [link](https://github.com/dotnet/machinelearning-samples/tree/main).