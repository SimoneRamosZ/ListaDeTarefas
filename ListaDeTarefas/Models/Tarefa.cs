namespace ListaDeTarefas.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public bool Concluido { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
}