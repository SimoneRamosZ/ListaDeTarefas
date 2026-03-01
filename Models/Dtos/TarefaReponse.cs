namespace ListaDeTarefas.Api.Models.Dtos;

public record TarefaResponse(int Id, string Titulo, string Descricao, bool Concluido);
