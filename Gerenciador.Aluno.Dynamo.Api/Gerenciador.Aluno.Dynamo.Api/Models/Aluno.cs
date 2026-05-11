using Amazon.DynamoDBv2.DataModel;

namespace Gerenciador.Aluno.Dynamo.Api.Models
{
    [DynamoDBTable("alunos")]
    public class Aluno
    {
        [DynamoDBHashKey("id")]
        public int? Id { get; set; }
        [DynamoDBProperty("nome")]
        public string? Nome { get; set; }
        [DynamoDBProperty("sobrenome")]
        public string? Sobrenome { get; set; }
        [DynamoDBProperty("classe")]
        public int? Classe { get; set; }
        [DynamoDBProperty("pais")]
        public string? Pais { get; set; }
    }
}
