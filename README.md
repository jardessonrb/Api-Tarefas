# Api-Tarefas

Projeto criado para estudo de desenvolvimento de API com C#

### Tecnologias
 - C# (Com .NET versão 8)
 - Postgres
 - Docker
 - IDE Rider JetBrains

### Alguns comandos úteis para criação e interação com banco de dados no Postgres via Docker
```
$ docker pull postgres 
//Baixar a imagem do dockerhub

$ docker run -d -p 5432:5432 --name apitarefa -e POSTGRES_PASSWORD=admin postgres
//Criando um container para subir a imagem do postgres

$ docker exec -it apitarefa /bin/bash
//Entrando no terminal interativo

$ psql -U postgres
//Entrando no servidor de banco de dados com o usuário postgres

$ CREATE DATABASE dbapitarefa;
//Criando um banco de dados

$ \c dbapitarefa
//Entrando no banco de dados

$ \d
//Lista as tabelas
```

### Alguns comando úteis para migrations via terminal
```
$ dotnet ef migrations add Inicializaco-Database-ApiTarefa
//Esse comando cria as migrations para o projeto, depois que ele
//está configurado

$ dotnet ef database update
//Persiste as migrations no banco de dados.

$ dotnet ef database update 0
//Dar rollback na ultima migration

$ dotnet ef database drop
//Em caso de pânico apague o banco e roda as migrations novamente rsrs
```
