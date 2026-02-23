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

    public async Task<Tarefa?> BuscarTarefa(int id)
    {
        var tarefaEncontrada = await _dbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

        if (tarefaEncontrada == null)
            return null;

        return tarefaEncontrada;
    }

    public async Task<Tarefa?> AtualizarTarefa(int id, Tarefa tarefa)
    {
        var tarefaEncontrada = await _dbContext.Tarefas.
            FirstOrDefaultAsync(t => t.Id == id);
        
        if (tarefaEncontrada == null)
            return null;

        tarefaEncontrada.Titulo = tarefa.Titulo;
        tarefaEncontrada.Descricao = tarefa.Descricao;
        tarefaEncontrada.Concluido = tarefa.Concluido;

        if (tarefaEncontrada.Concluido)
            tarefaEncontrada.DataConclusao = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return tarefaEncontrada;
    }

    public async Task<int> DeletarTarefa(int id)
    {
        var tarefaEncontrada = await _dbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

        if (tarefaEncontrada == null)
            return 0;
        
        _dbContext.Tarefas.Remove(tarefaEncontrada);

        await _dbContext.SaveChangesAsync();

        return tarefaEncontrada.Id;
    }
}