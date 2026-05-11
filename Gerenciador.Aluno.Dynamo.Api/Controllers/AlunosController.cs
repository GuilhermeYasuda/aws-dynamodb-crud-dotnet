using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Aluno.Dynamo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IDynamoDBContext _context;

        public AlunosController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet("{idAluno}")]
        public async Task<IActionResult> GetAlunoPorId(int idAluno)
        {
            var aluno = await _context.LoadAsync<Models.Aluno>(idAluno);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            var alunos = await _context.ScanAsync<Models.Aluno>([]).GetRemainingAsync();
            return Ok(alunos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAluno([FromBody] Models.Aluno alunoRequest)
        {
            var aluno = await _context.LoadAsync<Models.Aluno>(alunoRequest.Id);
            if (aluno != null)
            {
                return BadRequest($"O aluno com Id {alunoRequest.Id} já existe.");
            }
            await _context.SaveAsync(alunoRequest);
            return Ok(alunoRequest);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAluno([FromBody] Models.Aluno alunoRequest)
        {
            var aluno = await _context.LoadAsync<Models.Aluno>(alunoRequest.Id);
            if (aluno == null)
            {
                return NotFound();
            }
            await _context.SaveAsync(alunoRequest);
            return Ok(alunoRequest);
        }

        [HttpDelete("{idAluno}")]
        public async Task<IActionResult> DeletarAluno(int idAluno)
        {
            var aluno = await _context.LoadAsync<Models.Aluno>(idAluno);
            if (aluno == null)
            {
                return NotFound();
            }
            await _context.DeleteAsync(aluno);
            return NoContent();
        }
    }
}
