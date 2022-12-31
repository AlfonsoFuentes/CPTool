using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate
{
    public class SignalModifierValidator : AbstractValidator<CommandSignalModifier>
    {
        private readonly IRepositorySignalModifier _SignalModifierRepository;
        public SignalModifierValidator(IRepositorySignalModifier SignalModifierRepository)
        {
            _SignalModifierRepository = SignalModifierRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandSignalModifier e, CancellationToken token)
        {
            return !await _SignalModifierRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
