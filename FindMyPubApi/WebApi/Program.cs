using AutoMapper;
using FindMyPubApi.BusinessLogic.AutoMapper;
using FindMyPubApi.BusinessLogic.Contexts;
using FindMyPubApi.BusinessLogic.Models;
using FindMyPubApi.BusinessLogic.Repositories;
using FindMyPubApi.BusinessLogic.Seeding;
using FindMyPubApi.BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyPubDbContext>(optionsAction: opt =>
        opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()),
    contextLifetime: ServiceLifetime.Scoped,
    optionsLifetime: ServiceLifetime.Singleton
);
builder.Services.AddSingleton<ISeeder, CsvSeeder>();
builder.Services.AddSingleton<ICsvService, CsvService>();
AddAutoMapper(builder);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

SeedDatabase(app);

app.Run();

void AddAutoMapper(WebApplicationBuilder webApplicationBuilder)
{
    var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
    mapperConfiguration.AssertConfigurationIsValid();
    var mapper = mapperConfiguration.CreateMapper();
    webApplicationBuilder.Services.AddSingleton(mapper);
}

void SeedDatabase(WebApplication webApplication)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<MyPubDbContext>();
    context.Database.EnsureCreated();
    context.SaveChanges();
}
