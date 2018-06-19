# Analise comparativa de desempenho do mongoDB em dotnet core e Python 3

## Objetivo

O objetivo deste trabalho é realizar uma análise comparativa de desempenho das operações CRUD (Create, Read, Update, Delete) de dados no MongoDB, usando aplicações escritas nas linguangens C# (Com framework  DotNet Core) e Python 3.

## Descrição das versões dos softwares utilizados

*   DotNet Core 2.1
*   Python 3
*   MongoDB 3.6

## Arquitetura do ambiente

*   Processador: Ryzen 1800x
*   Memória: 16G 3000mhz
*   Sistema Operacional: Windows 10
*   Disco: SSD Samsung EVO 750

## Arquitetura da solução

Serão criadas 2 aplicações consoles para realizar os testes das operações CRUD, afim de obter uma analise quantitativa de desempenho.

### MongoDB

Será utilizado a instalação padrão do MongoDB.

### DotNet

Será utilizado o drive padrão fornecido pela documentação do [MongoDB](https://docs.mongodb.com/ecosystem/drivers/csharp/)

### Python

Será utilizado o drive padrão fornecido pela documentação do [MongoDB](https://api.mongodb.com/python/current/)

## Análise dos Resultados
Os dados gerados serão armazedos em uma outra collection no MongoDB para análise posterior. Após análise dos dados, foi constatado que o Python mantem regulariedade nos dados de coletados variando de 899 nanosegundos à 1.2 millesegoundo em operações de insert, enquanto o C# tende a variar esses números entre 0.15 millesegundos e 0.17 milesegundos. No PowerPoint presente neste repositório será possível visualizar todos os gráficos dos testes realizardos com mil iterações.

# Downloads:
- [Apresentação](https://github.com/liphvf/MongoCompare/blob/master/Analise.pptx?raw=true)
- [Dados do C#](https://github.com/liphvf/MongoCompare/blob/master/CSVs/ResultadoFinalCsharp.xlsx?raw=true)
- [Dados do Python](https://github.com/liphvf/MongoCompare/blob/master/CSVs/ResultadoFinalPython.xlsx?raw=true)