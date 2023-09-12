# Body Fatigue Predict Rating ML #

Simple Web API to predict a rating of body fatigue level using a [ML.NET](https://learn.microsoft.com/en-us/dotnet/machine-learning/)

Data to create machine learning model was collected using:<br>

[Body Fatigue App](https://github.com/MaciejTrudnos/Body-Fatigue-App)</br> 
[Body Fatigue Device](https://github.com/MaciejTrudnos/Body-Fatigue-Device)

#### Level of body fatigue
- Rested (1)
- Fairly rested (2)
- Tired (3)

#### Example of response body
```
{
  "predictedLabel": 2,
  "score": [
    0.3962476,
    0.54935247,
    0.054399878
  ]
}
```