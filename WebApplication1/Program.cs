using Microsoft.EntityFrameworkCore;

using Ukim.MusicAPI.Data;
using Ukim.MusicAPI.Services;
using Ukim.FacebookAPIClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicDbContext>(options => options.UseInMemoryDatabase(databaseName: "MusicDb"));

builder.Services.AddFacebookService();

builder.Services.AddHostedService<FacebookCrawlerService>();

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

MusicDbInitializer.SeedStaticData(app);

app.Run();
