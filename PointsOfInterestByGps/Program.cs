using Microsoft.EntityFrameworkCore;
using PointsOfInterestByGps.Repositories;
using PointsOfInterestByGps.Contexts;
using PointsOfInterestByGps.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<PointLocaleCoordinateContext>(opt => opt.UseInMemoryDatabase("pointCoordinate"))
    .AddScoped<IPoinsLocaleCoordinateRepository, PoinsLocaleCoordinateRepository>();

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
