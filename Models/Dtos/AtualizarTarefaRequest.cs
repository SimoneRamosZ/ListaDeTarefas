namespace ListaDeTarefas.Models.Dtos;

public record AtualizarTarefaRequest(
    string Titulo,
    string? Descricao,
    bool Concluido
);