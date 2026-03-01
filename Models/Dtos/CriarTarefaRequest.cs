namespace ListaDeTarefas.Api.Models.Dtos;

public record CriarTarefaRequest(
    string Titulo,
    string? Descricao
);