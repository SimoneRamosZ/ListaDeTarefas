namespace ListaDeTarefas.Models.Dtos;

public static class TarefaMappings
{
    public static TarefaResponse ToResponse(this Tarefa tarefa)
        => new(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.Concluido
        );
}