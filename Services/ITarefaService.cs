using ListaDeTarefas.Models;
using ListaDeTarefas.Models.Dtos;

namespace ListaDeTarefas.Services;

public interface ITarefaService
{
    Task CriarTarefa(Tarefa tarefa);
    Task<List<Tarefa>> BuscarTodasTarefas();
    Task<Tarefa?> BuscarTarefa(int id);
    Task<Tarefa?> AtualizarTarefa(int id, AtualizarTarefaRequest request);
    Task<int> DeletarTarefa(int id);
}