using DotNet.Data;
using DotNet.DbConnection;
using DotNet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure Database connection
builder.Services.AddDbContext<DatabaseContext>(option => option.UseInMemoryDatabase("InMemory"));

builder.Services.AddScoped<ICryptoCoinService, CryptoCoinService>();

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

// Add CORS middleware
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000") // Replace with your React app's URL
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthorization();

InMemorySeedData.AddTestDataInMemory(app.Services);

app.MapControllers();

app.Run();
