using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate
{
    public class MeasuredVariableModifierValidator : AbstractValidator<CommandMeasuredVariableModifier>
    {
        private readonly IRepositoryMeasuredVariableModifier _MeasuredVariableModifierRepository;
        public MeasuredVariableModifierValidator(IRepositoryMeasuredVariableModifier MeasuredVariableModifierRepository)
        {
            _MeasuredVariableModifierRepository = MeasuredVariableModifierRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandMeasuredVariableModifier e, CancellationToken token)
        {
            return !await _MeasuredVariableModifierRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
