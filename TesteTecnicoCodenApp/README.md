# API de Orçamentos - Oficina Mecânica

API REST em **ASP.NET Core (.NET 9)** para cadastro de orçamentos de uma oficina mecânica.
Projeto desenvolvido como teste técnico para a vaga de Desenvolvedor Back-end .NET Júnior.

## O que a API faz

Expõe um endpoint para cadastrar um orçamento contendo cliente, veículo e uma lista de itens.
A API valida os dados de entrada, calcula o valor total e persiste o orçamento.

## Tecnologias

- ASP.NET Core (.NET 9) - Web API
- Entity Framework Core (provider InMemory) - acesso a dados
- OpenAPI - documentação do endpoint em ambiente de desenvolvimento

> O banco é **InMemory**: os dados existem apenas enquanto a aplicação está rodando e
> são perdidos ao reiniciar. Isso facilita rodar o projeto sem instalar SQL Server.
> Para usar SQL Server bastaria trocar `UseInMemoryDatabase` por `UseSqlServer` no `Program.cs`.

## Estrutura do projeto

```
Controllers/   -> Recebe a requisição HTTP e devolve a resposta HTTP. Sem regra de negócio.
DTOs/          -> Objetos de entrada (Request) e saída (Response) da API.
Validators/    -> Validação das regras de entrada do orçamento.
Services/      -> Regra de negócio: monta as entidades, calcula totais e salva.
Models/        -> Entidades persistidas no banco (Orcamento, OrcamentoItem).
Data/          -> AppDbContext: ponte com o Entity Framework Core.
Program.cs     -> Configuração da aplicação e injeção de dependência.
```

Fluxo de uma requisição:

```
HTTP -> Controller -> Validator -> Service -> AppDbContext (EF Core) -> Banco InMemory
```

## Como rodar

Pré-requisito: **.NET 9 SDK** instalado.

```bash
dotnet run
```

A API sobe em `http://localhost:5296` (ver `Properties/launchSettings.json`).

## Endpoint

### POST /api/orcamentos

Cadastra um novo orçamento.

**Corpo da requisição:**

```json
{
  "clienteId": 10,
  "veiculoId": 25,
  "itens": [
    { "descricao": "Troca de óleo", "quantidade": 1, "valorUnitario": 120.00 },
    { "descricao": "Filtro de óleo", "quantidade": 1, "valorUnitario": 45.00 }
  ]
}
```

**Regras de validação:**

- `clienteId` é obrigatório (maior que zero).
- `veiculoId` é obrigatório (maior que zero).
- Deve existir pelo menos 1 item.
- Cada item deve ter descrição, quantidade maior que zero e valor unitário maior que zero.
- O valor total é calculado pela API (`quantidade * valorUnitario` de cada item, somados).

**Resposta de sucesso - 201 Created:**

```json
{
  "id": 1,
  "status": "Aberto",
  "valorTotal": 165.00,
  "dataCriacao": "2026-05-14T12:00:00Z"
}
```

**Resposta de erro - 400 Bad Request:**

```json
{
  "erros": [
    "clienteId é obrigatório.",
    "O orçamento deve ter pelo menos 1 item."
  ]
}
```

## Como testar

O arquivo `TesteTecnicoCodenApp.http` já contém requisições prontas (sucesso e erros)
e pode ser executado direto pelo Visual Studio ou pela extensão REST Client do VS Code.

Também é possível testar pelo Postman ou pelo navegador na rota `/openapi/v1.json`
(disponível em ambiente de desenvolvimento).
