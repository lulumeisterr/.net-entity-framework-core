# Configuração de portas
  - Properties > LaunchSetting > applicationUrl
# Endpoints de teste
  - https://localhost:7198/swagger/index.html
# Sobre Injeção de dependências
  - Estamos criando a injeção de dependencias por construtor onde o mesmo
    é identificado atraves de escopos. A Identificação de injeção ocorre
    por meios de contratos e referencia de contrato(Quem implementa o contrato).
    Para cada construtor na classe de servico, ou construtores assinados com classe
    devem ser especificado no container, para que o framework consiga encontrar 
    todas as referencias necessarias. O Framework só associa a injeção se todos os pontos
    for mapeado corretamente.

    # Ciclos de vida
      - Scoped : Para cada requisição solicitada no injetor, o mesmo cria apenas uma unica instancia de objeto na memoria e reutiliza a mesma instancia até finalizar o ciclo da aplicação ou seja até o 200 OK ou erro no mesmo contexto. 

      - Transient : Para cada instancia solicitada a partir do injetor de dependencia, é gerada uma nova instancia de objeto na memoria, só é discartado quando a requisição é encerrada.

      - Singleton : A instancia só é criada somente se for chamar via injetor mas a finalização do ciclo dela só encerra se a aplicação for finalizada.

    # Multiplas classes para a mesma interface.
      - Por padrão o framework utilizada a ultima instancia configurada no container.
        -  Para fazer seleções de instancia de injecao de dependencia, deve-se passar no 
           construtor uma lista de   operacoes e buscar a operação desejada.

# Sobre Middleware
   
   Middleware é um componente isolado no qual faz parte de um fluxo de execução(pipeline) da aplicação
   funcionando no processamento de requisição http, Exceptions etc, podendo ou não interromper um fluxo
   caso a solicitação nao seja atendida corretamente.

  - Run : adiciona um middleware ao pipeline do Asp.Net Core. Isso significa que após sua execução, ocorrerá uma interrupção do fluxo no pipeline causando um curto-circuito e nenhum outro middleware será executado.

  - Use : adiciona um middleware in-line no pipeline, Isso significa que após a execução desse middleware, ele fará uma chamada para o próximo.

  - Map : cria uma ramificação do pipeline com base no caminho informado. O exemplo abaixo do Microsoft docs, explica bem esse cenário.

# Comandos de execução
  - dotnet watch run
  - donet run
  - dotnet web
  - donet console
   


  
  
