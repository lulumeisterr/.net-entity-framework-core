# .net-entity-framework-core
 - Adicionando o Entity Framework via Nuget
   - dotnet add package EntityFramework --version 6.4.4
   - dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
   - dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
   - dotnet tool install --global dotnet-ef

# Sobre Migration
  - Sera gerado uma migration conotada como timestamp + nome da tabela
    -  UP : Aplicação a ser feita no banco, por exemplo (banco de dados recebendo a criação da tabela)
    -  Down : Reverte a migração do comando executado anteriormente

  - Snapshot : Reflete a estrutura atual do seu banco de dados. Ou seja é um utilitario que ajuda o entity framework saber o'que mudou.

  # Comandos
   - dotnet ef migrations add nomeDaTabela
   - dotnet ef migrations remove
   - dotnet ef database update (Atualiza o contexto do banco via migration)


# FluentAPI
  - 