using ListaDeTarefas.Api.Models;
using ListaDeTarefas.Api.Models.Dtos;

namespace ListaDeTarefas.Api.Services;

public interface ITarefaService
{
    Task CriarTarefa(Tarefa tarefa);
    Task<List<Tarefa>> BuscarTodasTarefas();
    Task<Tarefa?> BuscarTarefa(int id);
    Task<Tarefa?> AtualizarTarefa(int id, AtualizarTarefaRequest request);
    Task<int> DeletarTarefa(int id);
}