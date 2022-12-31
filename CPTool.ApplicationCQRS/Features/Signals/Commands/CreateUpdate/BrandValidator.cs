using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate
{
    public class SignalValidator : AbstractValidator<CommandSignal>
    {
        private readonly IRepositorySignal _SignalRepository;
        public SignalValidator(IRepositorySignal SignalRepository)
        {
            _SignalRepository = SignalRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandSignal e, CancellationToken token)
        {
            return !await _SignalRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
