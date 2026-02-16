using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Services;

public class TarefaService : ITarefaService
{
    private readonly TarefaDbContext _dbContext;

    public TarefaService(TarefaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CriarTarefa(Tarefa tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Tarefa>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas.ToListAsync();
    }
}