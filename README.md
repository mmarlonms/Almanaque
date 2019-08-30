#Projeto Acerto

####Almanque Herois Márvel


**Desafio:**

------------


Você foi convocado pela Marvel para participar de um novo projeto que tem como objetivo facilitar o acesso a informação de seus super-heróis favoritos. 
A ideia consiste em criar um mecanismo de busca que retorne as informações listadas abaixo apenas realizando uma pesquisa com o nome do personagem:    


- ID 
- Nome 
- Descrição  Histórias 
- Foto  


Para simplificar o acesso à informaçãoa Marvel disponibilizou uma API pública com todas as informações sobre os seus personagens, você poderá obter acesso a API se cadastrando no portal do desenvolvedor (​https://developer.marvel.com/​). A documentação completa sobre todos os métodos desta API está disponível em: (​https://developer.marvel.com/docs​).    

Então sua tarefa é criar uma API para a busca dos personagens pelo nome.    

**Requisitos**  :
- O sistema deverá armazenar todas as pesquisas realizadas, juntamente  com a data e hora;  
- O sistema deverá aceitar apenas chamadas seguras (HTTPS);   
- Você deverá ter testes para todos os métodos da sua API.      
- O projeto deverá ser hospedado no bitbucketutilizandooGITcomoferramenta de versionamento


**Solução:**

------------


Para resolver o problema proposto foi utilizado a plataforma .net core por se tratar de um tecnologia em constante evolução e expertise do desenvolver ( no caso eu ) na liguagem. 

A Solução foi desenvolvida seguindo as boas práticas de desenvolvimento  DDD e SOLID. 
Como Arquitetura de software foi adotado o padrão **Hexagonal** por possibilitar melhor coesão e menor acoplamento entre as camadas, facilitando evoluções futuras. Para referências de projetos com arquiteturas exagonais ficam os seguintes links: 

- [Furiza](https://github.com/ivanborges/furiza-aspnetcore "Furiza")

- [Manga Clean Architecture](https://github.com/ivanpaulovich/clean-architecture-manga "Manga Clean Architecture")

- [Opala](https://github.com/OleConsignado/opala "Opala")


Para salvar todas as requisições feitas no site foi tuilizado o sistema de logs realizados pelo [Serilog](https://serilog.net/)  e feito algumas modificaçõe para salvar o Log em arquivo e um tabela do SQL server de acordo com a seguinte configuração no Startup do projeto de WebApi ( Seção 6):

    
            
                //File
                loggerConfiguration = loggerConfiguration.WriteTo.Async(a => a.File($"Logs/log-.txt"));

                //Sql Server
                var tableName = "Logs";
                var columnOption = new ColumnOptions();
                columnOption.Store.Remove(StandardColumn.MessageTemplate);
                loggerConfiguration.WriteTo.MSSqlServer(Configuration.GetConnectionString("LoggerDatabase"), tableName, columnOptions: columnOption);


Foram utilizadas outras fontes para implementar a solução: 

[# Utilizando Log em ASP .NET Core]([https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5](https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5))

[# ASP.NET Core File Logging in one line of code](https://nblumhardt.com/2016/10/aspnet-core-file-logger/)

[# Como traduzir textos - Google Tradutor V2](https://cloud.google.com/translate/docs/translating-text?hl=pt-br)

[# File Logging And MS SQL Logging Using Serilog With ASP.NET Core 2.0](https://www.c-sharpcorner.com/article/file-logging-and-ms-sql-logging-using-serilog-with-asp-net-core-2-0/)

[# A Cleaner Way to Create Mocks in .NET](https://medium.com/webcom-engineering-and-product/a-cleaner-way-to-create-mocks-in-net-6e039c3d1db0)

[# Advanced Architecture for ASP.NET Core Web API](https://www.infoq.com/articles/advanced-architecture-aspnet-core)

**Estrutura do projeto:**

O projeto segue com as seguintes camadas: 

 **0 - Aplicação**
 
	Acerto.MarvelHeros.Almanaque.Aplication

**2 - Dominio**   

	Acerto.MarvelHeros.Almanaque.Dominio

**4 - Infra**  

	Acerto.MarvelHeros.Almanaque.GoogleTradutorAdapter
	Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions
	Acerto.MarvelHeros.Almanaque.MarvelApiAdapter
	Acerto.MarvelHeros.Almanaque.Md5
	Acerto.MarvelHeros.Almanaque.Md5.Abstractions

**6 - Api **  

	Acerto.MarvelHeros.Almanaque.WebApi

**7 - Recursos**

	Outros Arquivos

**8 - Testes**

	Acerto.MarvelHeros.Almanaque.Testes

Onde temos, a camada 0 Como a camada da regra de negócio da aplicação, nela está contida toda a regra envolvida da palicação. 

A camada 2 é a responsável pelo meu dóminio, nela temos os contratos das interfaces, os objetos de domínio e as excessões que meu negócio pode gerar.

A camada 6 é responsavel pela camada de aprensentação nela colocamos todas as interfaces humanas, APIs ( Swagger ), Sites, Sistemas entre outras coisas. 

A camada 7 foi criada para abrigar alguns recursos de fora do projeto como por exemplo o script de criação da tabela utilizada no log da aplicação. 

E por último mas não menos importante a camada 8 de testes, no qual são escritos testes automatizados para validar se o sistema não possui falhas.

**Requisitos para execução do projeto:**

O projeto foi desenvolvido na plataforma .net core 2.1 ou seja, é necessário este SDK para executa-lo ;).

Para o projeto funcionar corretamente deve-se executar o script **Script de Create da Tabela de Log** (disponível na seção 7) em uma servidor de dados SQL Server e realizar o apontamento do mesmo no **appsettings.json** no projeto de WebApi ( Seção 6). 

É aconcelhável que se crie uma conta no https://developer.marvel.com/ e utilize a suas credencias fornecidas para sua conta. Neste caso deve-se realizar também o apontamento no **appsettings.json** no projeto de WebApi (Seção 6). 

**Plus++**
------------

Devido ao fato da API realizar busca pelos herois com em Inglés foi acrescentado um método para buscar o nome dos personagens em portugues. 

`/BuscarHeroi/{nome}/ptBr`

Para isso foi criado um Adapter que se conecta ao google tradutor e traduz o nome do heroi para o inglês, para então busca-lo na base da marvel. 

Pelo fato do google tradutor ser pago o método foi colocado como obsoleto, entretanto para utiliza-lo basta criar uma conta no [Google Developers](https://developers.google.com/ "Google Developers") , assinar o serviço e configurar a chave no **appsettings.json** no projeto de WebApi (Seção 6).


**Conclusão**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos com Injeção de Dependência, arquitetura exagonal e principalmente utilização de testes mocados na aplicação, além de outros conceitos. 

**Melhorias**

Como melhorias futuras proponho a adoção de mais métodos de negocio e a inclusão de filtros personalizados para tratar exceções de negócios. 
	
Proponho também a segregação de alguns itens de configuração como Logs, Swagger entre outras coisa sem pacotes separados para serem reutilizados por outras aplicações. 

Para melhorar a segunça da API proponho incluir a autenticação via Bearer Token e criar um servidor de autenticação como feito no meu Git Hub: https://github.com/MarlonMiranda/AuthServer

Uma observação que serve como melhoria futura é portar os projetos **Md5**, **Md5.Abstraction** , **GoogleTradutorAdapter** e **GoogleTradutor.Abstractions** para o Nuget e deixar encapsulado para a aplicação. 