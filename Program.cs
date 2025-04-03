using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging to the console and a log file (with 1-minute rolling interval)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Logs to the console
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day) // Logs to a file with a 1-minute rolling interval
    .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging in ASP.NET Core

// Add services to the container
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run("http://0.0.0.0:5000");
