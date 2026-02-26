namespace ListaDeTarefas.Models.Dtos;

public record CriarTarefaRequest(
    string Titulo,
    string? Descricao
);