# Gerenciador de Alunos com DynamoDB

Uma aplicação ASP.NET Core Web API para gerenciamento de alunos utilizando AWS DynamoDB como banco de dados NoSQL. Esta aplicação demonstra operações CRUD (Create, Read, Update, Delete) com DynamoDB em um ambiente .NET 10.

## 📚 Sobre o Tutorial

Este projeto foi desenvolvido seguindo o tutorial oficial:

**[CRUD with DynamoDB in ASP.NET Core - Getting Started with AWS DynamoDB Simplified](https://codewithmukesh.com/blog/crud-with-dynamodb-in-aspnet-core/)**

Autor: [Mukesh Murugan](https://www.linkedin.com/in/iammukeshm)  
Blog: [Code With Mukesh](https://codewithmukesh.com/)

## 🎯 Funcionalidades

- ✅ **Criar Aluno**: Adicionar novos alunos ao DynamoDB
- ✅ **Listar Alunos**: Recuperar todos os alunos cadastrados
- ✅ **Obter Aluno por ID**: Buscar um aluno específico pelo ID
- ✅ **Atualizar Aluno**: Modificar dados de um aluno existente
- ✅ **Deletar Aluno**: Remover um aluno do banco de dados

## 🛠 Tecnologias Utilizadas

- **.NET 10**: Framework moderno para desenvolvimento de aplicações
- **ASP.NET Core Web API**: Framework para criar APIs REST
- **AWS DynamoDB**: Banco de dados NoSQL gerenciado pela Amazon
- **AWS SDK para .NET**: Bibliotecas para integração com serviços AWS
- **Scalar**: Documentação e teste interativo da API (alternativa moderna ao Swagger)

## 📋 Pré-requisitos

Antes de iniciar, você precisa ter:

- Visual Studio 2022 ou superior (Community Edition é suficiente)
- .NET 10 SDK instalado
- Uma conta AWS (pode usar a camada gratuita)
- AWS CLI configurado localmente
- Credenciais AWS com permissões para DynamoDB

## 🚀 Configuração Inicial

### 1. Clonar o Repositório

```bash
git clone https://github.com/GuilhermeYasuda/aws-dynamodb-crud-dotnet.git
cd Gerenciador.Aluno.Dynamo.Api
```

### 2. Configurar Credenciais AWS

Certifique-se de que suas credenciais AWS estão configuradas localmente. Se não estiver, configure usando o AWS CLI:

```bash
aws configure --profile seu-perfil
```

Defina:
- AWS Access Key ID
- AWS Secret Access Key
- Default region (ex: us-east-1, sa-east-1)
- Default output format (json é recomendado)

### 3. Configurar appsettings.json

Abra o arquivo `appsettings.json` e configure o perfil AWS e a região:

```json
{
  "AWS": {
    "Profile": "seu-perfil",
    "Region": "sa-east-1"
  }
}
```

### 4. Criar Tabela no DynamoDB

No AWS Console:

1. Acesse o serviço DynamoDB
2. Clique em "Criar tabela"
3. Configure:
   - **Nome da tabela**: `alunos`
   - **Chave de partição**: `id` (Número)
   - Deixe as outras configurações padrão
4. Clique em "Criar tabela"

Aguarde a tabela ficar ativa (status "ATIVA").

### 5. Restaurar Dependências e Executar

```bash
dotnet restore
dotnet run
```

A aplicação estará disponível em `https://localhost:5001` (ou a porta exibida no console).

## 📖 API Endpoints

### Obter um Aluno por ID
```http
GET /api/alunos/{idAluno}
```

**Resposta (200 OK)**:
```json
{
  "id": 1,
  "nome": "João",
  "sobrenome": "Silva",
  "classe": 10,
  "pais": "Brasil"
}
```

### Listar Todos os Alunos
```http
GET /api/alunos
```

**Resposta (200 OK)**:
```json
[
  {
    "id": 1,
    "nome": "João",
    "sobrenome": "Silva",
    "classe": 10,
    "pais": "Brasil"
  },
  {
    "id": 2,
    "nome": "Maria",
    "sobrenome": "Santos",
    "classe": 10,
    "pais": "Brasil"
  }
]
```

### Criar um Novo Aluno
```http
POST /api/alunos
Content-Type: application/json

{
  "id": 3,
  "nome": "Pedro",
  "sobrenome": "Oliveira",
  "classe": 11,
  "pais": "Brasil"
}
```

**Resposta (200 OK)**:
```json
{
  "id": 3,
  "nome": "Pedro",
  "sobrenome": "Oliveira",
  "classe": 11,
  "pais": "Brasil"
}
```

### Atualizar um Aluno
```http
PUT /api/alunos
Content-Type: application/json

{
  "id": 1,
  "nome": "João",
  "sobrenome": "Silva Atualizado",
  "classe": 11,
  "pais": "Brasil"
}
```

**Resposta (200 OK)**:
```json
{
  "id": 1,
  "nome": "João",
  "sobrenome": "Silva Atualizado",
  "classe": 11,
  "pais": "Brasil"
}
```

### Deletar um Aluno
```http
DELETE /api/alunos/{idAluno}
```

**Resposta (204 No Content)**

## 🧪 Testando a API

### Com Scalar

1. Execute a aplicação
2. Abra o navegador em `https://localhost:5001/scalar/v1`
3. Teste cada endpoint diretamente na interface interativa do Scalar

### Com cURL

**Exemplo - Criar um aluno**:
```bash
curl -X POST https://localhost:5001/api/alunos \
  -H "Content-Type: application/json" \
  -d '{"id": 1, "nome": "João", "sobrenome": "Silva", "classe": 10, "pais": "Brasil"}'
```

**Exemplo - Obter um aluno**:
```bash
curl -X GET https://localhost:5001/api/alunos/1
```

## 📁 Estrutura do Projeto

```
Gerenciador.Aluno.Dynamo.Api/
├── Controllers/
│   └── AlunosController.cs       # Endpoints da API
├── Models/
│   └── Aluno.cs                  # Modelo de domínio mapeado para DynamoDB
├── Program.cs                    # Configuração da aplicação
├── appsettings.json              # Configurações (AWS, logging, etc)
├── Gerenciador.Aluno.Dynamo.Api.csproj
└── README.md
```

## 🔑 Conceitos Principais

### DynamoDB
- **Tabela**: Coleção de itens em DynamoDB (equivalente a uma tabela relacional)
- **Chave de Partição (Partition Key)**: Identificador único do item (Id neste projeto)
- **Atributo**: Campo/propriedade do item no DynamoDB

### Decoradores Utilizados

- `[DynamoDBTable("alunos")]`: Mapeia a classe para a tabela DynamoDB "alunos"
- `[DynamoDBHashKey("id")]`: Define a chave primária
- `[DynamoDBProperty("nome")]`: Mapeia propriedades C# para atributos DynamoDB

## 🔒 Segurança

- As credenciais AWS são armazenadas **fora** do projeto (configuradas via AWS CLI)
- O `appsettings.json` não contém credenciais sensíveis
- Use IAM policies com permissões mínimas necessárias (AmazonDynamoDBFullAccess apenas para desenvolvimento)

## 📚 Recursos Adicionais

- [Documentação AWS DynamoDB](https://aws.amazon.com/dynamodb/)
- [AWS SDK para .NET](https://github.com/aws/aws-sdk-net)
- [Documentação ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/)
- [Camada Gratuita AWS](https://aws.amazon.com/free/)

## 📄 Licença

Este projeto segue os mesmos termos de licença do repositório original.

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para fazer fork do projeto e enviar pull requests com melhorias.

## 📧 Suporte

Para dúvidas sobre o tutorial original, visite:
- 🔗 [Code With Mukesh - Blog](https://codewithmukesh.com)
- 🔗 [Mukesh Murugan - LinkedIn](https://www.linkedin.com/in/iammukeshm)

---

**Desenvolvido em .NET 10**
