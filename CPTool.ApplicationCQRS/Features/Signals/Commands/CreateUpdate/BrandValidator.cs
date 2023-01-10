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
        private readonly IRepositorySignal _Repository;
        public SignalValidator(IRepositorySignal Repository)
        {
            _Repository = Repository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.SignalType!.Id)
                .NotEqual(0).WithMessage("Signal Type is required.");

            RuleFor(p => p.MWOItem!.Id)
                .NotEqual(0).WithMessage("Item is required.");

            RuleFor(p => p.SignalModifier!.Id)
            .NotEqual(0).WithMessage("Modifier is required.");

            RuleFor(p => p.IOType)
               .NotEqual(Domain.Enums.IOType.None)
               .WithMessage("I/O Type must be defined.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandSignal e, CancellationToken token)
        {
            var result = await _Repository.Any(x => x.Id != e.Id && x.Name == e.Name);
            return !result;
        }
    }
}
