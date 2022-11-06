using AutoMapper;
using FindMyPubApi.BusinessLogic.AutoMapper;
using FindMyPubApi.BusinessLogic.Contexts;
using FindMyPubApi.BusinessLogic.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.Run();

void AddAutoMapper(WebApplicationBuilder webApplicationBuilder)
{
    var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
    mapperConfiguration.AssertConfigurationIsValid();
    var mapper = mapperConfiguration.CreateMapper();
    webApplicationBuilder.Services.AddSingleton(mapper);
}
