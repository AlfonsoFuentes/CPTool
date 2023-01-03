using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate
{
    public class SignalTypeValidator : AbstractValidator<CommandSignalType>
    {
        private readonly IRepositorySignalType _SignalTypeRepository;
        public SignalTypeValidator(IRepositorySignalType SignalTypeRepository)
        {
            _SignalTypeRepository = SignalTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandSignalType e, CancellationToken token)
        {
            return !await _SignalTypeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
