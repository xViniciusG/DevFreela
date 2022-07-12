using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de descrição é de 255 Caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("O Tamanho máximo do TÍtulo é 30 Caracteres");
        }
    }
}
