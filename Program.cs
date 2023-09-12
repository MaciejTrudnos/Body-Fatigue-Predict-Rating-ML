using Body_Fatigue_Predict_Rating_ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/OrthostaticTestRating/Predict", (
    float averageLyingBPM,
    float maxLyingBPM,
    float minLyingBPM,
    float averageLyingIBI,
    float maxLyingIBI,
    float minLyingIBI,
    float averageStandingBPM,
    float maxStandingBPM,
    float minStandingBPM,
    float averageStandingIBI,
    float maxStandingIBI,
    float minStandingIBI) =>
{
    //Load sample data
    var sampleData = new OTRMLModel.ModelInput()
    {
        AverageLyingBPM = averageLyingBPM,
        MaxLyingBPM = maxLyingBPM,
        MinLyingBPM = minLyingBPM,
        AverageLyingIBI = averageLyingIBI,
        MaxLyingIBI = maxLyingIBI,
        MinLyingIBI = minLyingIBI,
        AverageStandingBPM = averageStandingBPM,
        MaxStandingBPM = maxStandingBPM,
        MinStandingBPM = minStandingBPM,
        AverageStandingIBI = averageStandingIBI,
        MaxStandingIBI = maxStandingIBI,
        MinStandingIBI = minStandingIBI,
        DiffPositionBpm = Math.Abs(averageLyingBPM - averageStandingBPM),
        DiffPositionIbi = Math.Abs(averageLyingIBI - averageStandingIBI),
    };

    //Load model and predict output
    var result = OTRMLModel.Predict(sampleData);

    return new
    {
        result.PredictedLabel,
        result.Score
    };
});

app.Run();