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
      
    }
}
