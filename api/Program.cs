using System.Data;
using Api.Data;
using Api.Extensions;
using Api.Services;
using Api.Services.DapperPoc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Serilog configuration

// builder.Host.ConfigureLogging(logging =>
// {
//     logging.ClearProviders(); // Remove the default logging providers
//     logging.AddSerilog(); // Use Serilog as the logger
// });

// Load the configuration from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath) // Set the base path to the project's root directory
    .AddJsonFile("appsettings.json")
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.AddSerilog(logger);

#endregion

#region Database configuration

// Configure Database connection InMemory
// builder.Services.AddDbContext<DbConnection>(option => option.UseInMemoryDatabase("InMemoryConnection"));

// Configure the SQL Server database connection for Entity Framework
builder.Services.AddDbContext<DbConnection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

// Configure the SQL Server database connection for Dapper
builder.Services.AddSingleton<IDbConnection>(provider => new SqlConnection(provider.GetRequiredService<IConfiguration>().GetConnectionString("SQLConnection")));

// To Do: ADO.NET

// Elastic Search - exstension methode
builder.Services.AddElasticSearch(builder.Configuration);

#endregion

#region Swagger configuration

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

builder.Services.AddControllers();

//DI
builder.Services.AddScoped<ICryptoCoinService, CryptoCoinInMemoryService>();
builder.Services.AddScoped<ICryptoCoinDapperService, CryptoCoinDapperService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORS middleware
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthorization();

//InMemorySeedData.AddTestDataInMemory(app.Services);

app.MapControllers();

app.Run();
