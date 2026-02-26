using ListaDeTarefas.Models;
using ListaDeTarefas.Models.Dtos;
using ListaDeTarefas.Services;
using ListaDeTarefas.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefaController(ITarefaService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<ActionResult<TarefaResponse>> CriarTarefa([FromBody] CriarTarefaRequest request)
    {
        var validator = new TarefaValidator();
        var result = await validator.ValidateAsync(request);

        if (!result.IsValid)
            return BadRequest(result.Errors.Select(e => e.ErrorMessage));

        var tarefa = new Tarefa
        {
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Concluido = false,
            DataCriacao = DateTime.UtcNow
        };

        await _service.CriarTarefa(tarefa);

        var response = new TarefaResponse(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.Concluido
        );
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TarefaResponse>>> BuscarTarefas()
    {
        var tarefas = await _service.BuscarTodasTarefas();

        var response = tarefas
            .Select(t => new TarefaResponse(
                t.Id,
                t.Titulo,
                t.Descricao,
                t.Concluido))
            .ToList();

        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Tarefa>>> BuscarTarefa(int id)
    {
        var tarefaEncontrada = await _service.BuscarTarefa(id);

        var tarefaResponse = tarefaEncontrada?.ToResponse();
        
        if (tarefaResponse == null)
            return NotFound($"Tarefa não encontrada para o id: {id}");

        return Ok(tarefaResponse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarTarefa(int id, [FromBody] AtualizarTarefaRequest request)
    {
        var atualizado = await _service.AtualizarTarefa(id, request);

        if (atualizado is null)
            return NotFound($"Tarefa não encontrada para o id: {id}");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletarTarefa(int id)
    {
        var idTarefaDeletada = await _service.DeletarTarefa(id);
        
        if(idTarefaDeletada == 0)
            return NotFound($"Tarefa não encontrada para o id: {id}");

        return Ok("Tarefa deletada com sucesso");
    }
}