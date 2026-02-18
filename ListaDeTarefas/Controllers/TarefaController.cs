using ListaDeTarefas.Models;
using ListaDeTarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefaController(ITarefaService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Tarefa tarefa)
    {
        await _service.CriarTarefa(tarefa);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<Tarefa>>> BuscarTarefas()
    {
        var tarefas = await _service.BuscarTodasTarefas();
        return Ok(tarefas);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefa)
    {
        var tarefaEncontrada = await _service.AtualizarTarefa(id, tarefa);

        if (tarefaEncontrada == null)
            return NotFound($"Tarefa não encontrada para o id: {id}");

        return Ok();
    }
}