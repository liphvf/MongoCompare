# Analise comparativa de desempenho do mongoDB em dotnet core e NodeJS

## Objetivo

O objetivo deste trabalho é realizar uma análise comparativa de desempenho das operações CRUD (Create, Read, Update, Delete) de dados no MongoDB, usando aplicações escritas nas linguangens C# e JavaScript utilizando os frameworks DotNet Core e NodeJS.

## Descrição das versões dos softwares utilizados

*   DotNet Core
*   NodeJS
*   MongoDB

## Arquitetura do ambiente

*   Processador: Ryzen 1800x
*   Memória: 16G 300mhz
*   Sistema Operacional: Windows 10
*   Disco: SSD Samsung EVO 750

## Arquitetura da solução

Serão criadas 2 aplicações consoles para realizar os testes de carga de operações CRUD, afim de obter uma analise quantitativa de desempenho.

### MongoDB

Será utilizado a instalação padrão do MongoDB.

### DotNet

Será utilizado o drive padrão fornecido pela documentação do [MongoDB](https://docs.mongodb.com/ecosystem/drivers/csharp/)

### NodeJS

Será utilizado o drive padrão fornecido pela documentação do [MongoDB](https://mongodb.github.io/node-mongodb-native/)

## Análise dos Resultados
Os dados gerados serão armazedos em uma outra instância do MongoDB para análise posterior. Está previsto como resulstado, gráficos para média, mediana, moda, máxima e minima dos dados. 