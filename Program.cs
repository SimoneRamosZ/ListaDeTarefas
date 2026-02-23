using ListaDeTarefas.Data;
using ListaDeTarefas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TarefaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
