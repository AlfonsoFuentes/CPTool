using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate
{
    public class GasketValidator : AbstractValidator<CommandGasket>
    {
        private readonly IRepositoryGasket _GasketRepository;
        public GasketValidator(IRepositoryGasket GasketRepository)
        {
            _GasketRepository = GasketRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandGasket e, CancellationToken token)
        {
            return !await _GasketRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
