using web_project_api.app.Repositorys;

namespace web_project_api.app.middleware;

    public class MiddleWareFilterHttpRequest {
    private readonly RequestDelegate _next;

    /**
        Reponsavel por realizar manipulação de requisições HTTP 
        e chamar o próximo middleware do pipeline;
    **/
    public MiddleWareFilterHttpRequest (RequestDelegate next) {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context, ITradeRepository _tradeRepository) {
        int getTradesQtd = _tradeRepository != null ? _tradeRepository.GetAllTrades().Count() : throw new Exception("Erro");

        if (getTradesQtd >= 10) {
            if (context.Request.Path.StartsWithSegments("/trades") && context.Request.Method == "POST") {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Limite de requisição atiginda");
            }

            if( context.Request.Path.StartsWithSegments("/tradesByDate")  && context.Request.Method == "GET") {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Limite de requisição atiginda");
            }
        } else {
            await _next(context);
        }
      }
}
