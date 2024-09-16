using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtém um endereço pelo ID",
            Description = "Retorna um endereço específico com base no ID fornecido."
        )]
        [SwaggerResponse(200, "Endereço encontrado", typeof(Endereco))]
        [SwaggerResponse(404, "Endereço não encontrado")]
        public IActionResult GetById(int id)
        {
            var endereco = _enderecoRepository.GetById(id);
            if (endereco == null)
                return NotFound();

            return Ok(endereco);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Cria um novo endereço",
            Description = "Adiciona um novo endereço ao banco de dados."
        )]
        [SwaggerResponse(201, "Endereço criado com sucesso", typeof(Endereco))]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Create([FromBody] Endereco endereco)
        {
            if (endereco == null)
                return BadRequest();

            _enderecoRepository.Add(endereco);
            return CreatedAtAction(nameof(GetById), new { id = endereco.EnderecoId }, endereco);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza um endereço existente",
            Description = "Atualiza as informações de um endereço com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Endereço atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Update(int id, [FromBody] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
                return BadRequest();

            _enderecoRepository.Update(endereco);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remove um endereço",
            Description = "Remove um endereço do banco de dados com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Endereço removido com sucesso")]
        [SwaggerResponse(404, "Endereço não encontrado")]
        public IActionResult Delete(int id)
        {
            _enderecoRepository.Delete(id);
            return NoContent();
        }
    }
}
