using FluentValidation;
using ListaDeTarefas.Models;

namespace ListaDeTarefas.Validators;

public class TarefaValidator : AbstractValidator<Tarefa>
{
    public TarefaValidator()
    {
        RuleFor(t => t.Titulo)
            .NotEmpty()
            .WithMessage("O título é obrigatório.")
            .MinimumLength(3)
            .WithMessage("O título deve ter pelo menos 3 caracteres.")
            .MaximumLength(100)
            .WithMessage("O título deve ter no máximo 100 caracteres.");

        RuleFor(t => t.Descricao)
            .MaximumLength(500)
            .WithMessage("A descrição deve ter no máximo 500 caracteres.");
    }
}