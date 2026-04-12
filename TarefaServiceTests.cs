using FluentAssertions;
using ListaDeTarefas.Api.Data;
using ListaDeTarefas.Api.Models;
using ListaDeTarefas.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Test
{
    public class TarefaServiceTests
    {
        [Fact]
        public async Task Deve_criar_uma_tarefa()
        {
            //arrange
            var context = CriarContextoEmMemoria();
            var service = new TarefaService(context);

            var tarefa = new Tarefa
            {
                Titulo = "Estudar xUnit",
                Descricao = "Aprender testes",
                Concluido = false
            };

            //act
            await service.CriarTarefa(tarefa);

            var tarefas = await context.Tarefas.ToListAsync();

            //assert
            tarefas.Should().HaveCount(1);
            tarefas.First().Titulo.Should().Be("Estudar xUnit");
        }

        [Fact]
        public async Task Deve_retornar_todas_as_tarefas()
        {
            var context = CriarContextoEmMemoria();

            context.Tarefas.AddRange(
                new Tarefa
                {
                    Titulo = "Tarefa 1",
                    Descricao = "Aprender testes",
                    Concluido = false
                },
                new Tarefa
                {
                    Titulo = "Tarefa 2",
                    Descricao = "Aprender testes",
                    Concluido = false
                }
            );

            await context.SaveChangesAsync();

            var service = new TarefaService(context);

            var resultado = await service.BuscarTodasTarefas();

            resultado.Should().HaveCount(2);
        }



        private TarefaDbContext CriarContextoEmMemoria()
        {
            var options = new DbContextOptionsBuilder<TarefaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new TarefaDbContext(options);
        }
    }
}
