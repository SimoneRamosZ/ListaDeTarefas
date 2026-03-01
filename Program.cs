using FluentValidation;
using ListaDeTarefas.Api.Data;
using ListaDeTarefas.Api.Services;
using ListaDeTarefas.Api.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TarefaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<TarefaDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddValidatorsFromAssemblyContaining<TarefaValidator>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

app.Run();
