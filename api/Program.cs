using System.Data;
using Api.Data;
using Api.Services;
using Api.Services.DapperPoc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure Database connection InMemory and SQL
// builder.Services.AddDbContext<DbConnection>(option => option.UseInMemoryDatabase("InMemoryConnection"));

// Configure the SQL Server database connection for Entity Framework
builder.Services.AddDbContext<DbConnection>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

// Configure the SQL Server database connection for Dapper
builder.Services.AddSingleton<IDbConnection>(provider => new SqlConnection(provider.GetRequiredService<IConfiguration>().GetConnectionString("SQLConnection")));

//DI
builder.Services.AddScoped<ICryptoCoinService, CryptoCoinInMemoryService>();
builder.Services.AddScoped<ICryptoCoinDapperService, CryptoCoinDapperService>();

// Swagger configuration
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
