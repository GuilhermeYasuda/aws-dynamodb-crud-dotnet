using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// carrega a configuração da AWS do arquivo appsettings.json para o ambiente de execução da aplicação
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
// registra o serviço do Amazon DynamoDB para ser injetado em outros componentes da aplicação para trabalhar com tabelas e itens
builder.Services.AddAWSService<IAmazonDynamoDB>();
// registra o serviço do DynamoDBContext para ser injetado em outros componentes da aplicação para realizar operações de leitura e escrita em tabelas do DynamoDB usando uma abordagem orientada a objetos
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
