using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data;

public class TarefaDbContext : IdentityDbContext
{
    public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}
