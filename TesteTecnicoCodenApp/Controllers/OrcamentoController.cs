using Microsoft.AspNetCore.Mvc;
using TesteTecnicoCodenApp.DTOs;
using TesteTecnicoCodenApp.Services;
using TesteTecnicoCodenApp.Validators;

namespace TesteTecnicoCodenApp.Controllers;

[ApiController]
[Route("api/orcamentos")]
public class OrcamentoController : ControllerBase
{
    private readonly OrcamentoService _service;

    public OrcamentoController(OrcamentoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] OrcamentoCriarRequest request)
    {
        var erros = OrcamentoCriarValidator.Validar(request);

        if (erros.Count > 0)
            return BadRequest(new { erros });

        var response = await _service.CriarAsync(request);

        return CreatedAtAction(nameof(Criar), new { id = response.Id }, response);
    }
}
