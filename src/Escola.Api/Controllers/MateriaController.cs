using Escola.Domain.Interfaces.Services;
using Escola.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        public MateriaController(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_materiaServico.ObterTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok(_materiaServico.ObterPorId(id));
        }

        [HttpGet("{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var result = _materiaServico.ObterPorNome(nome);
            return Ok(result);
        }
    }
}
