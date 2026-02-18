using ListaDeTarefas.Models;

namespace ListaDeTarefas.Services;

public interface ITarefaService
{
    Task CriarTarefa(Tarefa tarefa);
    Task<List<Tarefa>> BuscarTodasTarefas();
    Task<Tarefa?> AtualizarTarefa(int id, Tarefa tarefa);
}