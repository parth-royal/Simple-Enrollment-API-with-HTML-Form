curl http://localhost:5107/weatherforecast

```txt
curl http://localhost:5033/weatherforecast
[{"date":"2024-05-17","temperatureC":2,"summary":"Hot","temperatureF":35},{"date":"2024-05-18","temperatureC":8,"summary":"Mild","temperatureF":46},{"date":"2024-05-19","temperatureC":10,"summary":"Balmy","temperatureF":49},{"date":"2024-05-20","temperatureC":44,"summary":"Hot","temperatureF":111},{"date":"2024-05-21","temperatureC":12,"summary":"Warm","temperatureF":53}](base) $ 

```

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}







curl -X POST \
  -d "StudentId=1234" \
  -d "CourseId=5678" \
  -d "EnrollmentDate=2024-05-20" \
  http://localhost:5033/enrollments
