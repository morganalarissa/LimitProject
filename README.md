Sistema de Gestão de Limite para Transações PIX

## Recursos

- Cadastrar informações do cliente para gestão de limite (documento, número da agência, número da conta, limite para transações PIX).
- Buscar as informações de limite para contas cadastradas.
- Alterar o limite para transações PIX de uma conta cadastrada.
- Remover um registro do banco de dados de limite.
- Avaliar transações de PIX com base no limite disponível e aprovar ou negar a transação (processo a ser implementado).

## Tecnologias Utilizadas

- .NET 8
- Princípios de Clean Code e SOLID
- Padrão MVC
- DynamoDB AWS: A integração com o DynamoDB da AWS está em progresso, limitada pelo tempo disponível para este processo seletivo. Como solução temporária, implementei um contexto simulado para garantir a operacionalidade da aplicação, mantendo-a preparada para futuras integrações com diferentes tipos de bancos de dados, tanto relacionais quanto não relacionais.

# Instruções para instalação

Para rodar o LimitProject, siga os passos abaixo:

1 - Clone o repositório: https://github.com/morganalarissa/LimitProject.git

2 - Navegue até a pasta do projeto: 

- cd LimitProject

3 - Restaure os pacotes NuGet com o comando:
- dotnet restore

4 - Construa a solução: 
- dotnet build

5 - Inicie o projeto da API que é a principal interface para a aplicação:
- dotnet run --project LimitProject.Api

Com esses passos, a API Web deve estar rodando e pronta para ser utilizada.


# Projeto em desenvolvimento para processo seletivo.
