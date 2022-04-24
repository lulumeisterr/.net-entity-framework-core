using ITradeRepository = web_project_api.app.Repositorys.ITradeRepository;
using TradeRepository = web_project_api.app.Repositorys.TradeRepository;
using ApplicationDbContext = web_project_api.app.DbContextInit.ApplicationDbContext;
using web_project_api.app.middleware;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

/**
  Builder responsavel por
  ficar como listening para o recebimento de requisição
**/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Configuração de injeção de dependencias.
builder.Services.AddScoped<ITradeRepository,TradeRepository>();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.firstMiddleware();
app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);
app.Run();

