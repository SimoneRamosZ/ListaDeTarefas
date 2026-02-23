using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data;

public class TarefaDbContext : DbContext
{
    public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}
