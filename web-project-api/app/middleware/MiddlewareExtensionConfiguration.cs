namespace  web_project_api.app.middleware;
    /**
      Adicionando a configuração ao pipeline utilizando a interface
      IApplicationBuilder. Interface responsavel por
      fornecer uma solicitação de pipeline no app.

      Adicionando a classe no pipeline de execução
    **/
    public static class MyFirstMiddlewareExtension {
      public static IApplicationBuilder firstMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<MiddleWareFilterHttpRequest>();
    }
}
