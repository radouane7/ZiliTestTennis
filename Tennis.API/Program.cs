using Microsoft.AspNetCore.Hosting;
using Tennis.API;
using Tennis.Application.Feature.Queries.GetPlayerById;
using Tennis.Application.Feature.Queries.GetPlayersSortedByRank;
using Tennis.Application.Feature.Queries.GetPlayerStatistics;
using Tennis.Application.Mapping;
using Tennis.Domain.Abstractions;
using Tennis.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 

builder.Services.AddAutoMapper(typeof(PlayerMappingProfile)); 
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(GetPlayersSortedByRankQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetPlayerByIdQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetPlayerStatisticsQueryHandler).Assembly);
});
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Middleware pour gérer les exceptions
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
