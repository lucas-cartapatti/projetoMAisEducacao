
#  Grupo A Educação

## Resumo
- Aplicação Vue js com api em dotnet core e banco de dados MySQL.

### Tecnologia utilizada
- Linguagem : Dotnet Core
- Versão : 6.0.302
- Tipo da Aplicação : Api Serverless Lambda/AWS
___
- Vue Js
- Versão 4.5.13
- Aplicação Web (Front)
---
- MySql
- Versão 8
- Banco de Dados 

## Descrição
para executar o projeto web, acesse:
`cd ./projeto; npm run serve`
o mesmo criará um acesso no `localhost` provavelmente com a porta `8080` ou `8081`

para executar a api:
`cd ./api; dotnet run --project projeto-api/src/projeto-api/`
o mesmo criará um acesso no `localhost` provavelmente com a porta `62388` ou `62389`

para o banco de dados foram utilizados os comandos:
`create database teste`
```
use teste

create table alunos(
	Ra int not null,
    Nome varchar(250) not null,
    Email varchar(250) not null,
	Cpf varchar(15) not null,
    PRIMARY KEY (Ra)
)
```
Utilizado usuario local `User Id=admin;Password=admin"`
