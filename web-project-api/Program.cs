using ITradeRepository = web_project_api.app.Repositorys.ITradeRepository;
using TradeRepository = web_project_api.app.Repositorys.TradeRepository;
using ApplicationDbContext = web_project_api.app.DbContextInit.ApplicationDbContext;
using web_project_api.app.middleware;
using System.Text.Json.Serialization;

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

/****
        app.MapPost("/trades", (Trade trade) => {
            tradeRepository.add(trade);
            return Results.Created($"/trades/{trade.TradeId}",trade);
        });

        app.MapPut("/trades", (Trade trade) => {
            return tradeRepository.updateTrade(trade);
        });

        app.MapDelete("/trades/{tradeId}", ([FromRoute] int tradeId) => {
            tradeRepository.deleteTradeById(tradeId);
        });

        app.MapGet("/trades/{tradeId}", ([FromRoute] int tradeId) => {
            var result = tradeRepository.getTradeById(tradeId);
            if (result != null ) {
                return Results.Ok(tradeRepository.getTradeById(tradeId));
            } else {
                return Results.NotFound();
            }
        });

        app.MapGet("/trades", ([FromQuery] DateTime startDate , [FromQuery] DateTime endDate) => {  
            var result = tradeRepository.searchTradeByDate(startDate,endDate);
            if ( result == null || !result.Any() ) {
                return Results.NoContent();
            } else {
                return Results.Ok( tradeRepository.searchTradeByDate(startDate,endDate) ); 
            }
        
        });

        // Adicionando contexto no header no momento do request
        app.MapGet("/getTradeByHeader", (HttpRequest request) => {
            return request.Headers["tradeId"].ToString();
        });

        // Adicionando info no header no recebimento do response
        app.MapGet("/getheader", (HttpResponse response) => {
            response.Headers.Add("header","new header");
            return new {name = "success", header = "OK"};
        });
**/
