using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate
{
    public class InstrumentItemValidator : AbstractValidator<CommandInstrumentItem>
    {
        private readonly IRepositoryInstrumentItem _InstrumentItemRepository;
        public InstrumentItemValidator(IRepositoryInstrumentItem InstrumentItemRepository)
        {
            _InstrumentItemRepository = InstrumentItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandInstrumentItem e, CancellationToken token)
        {
            return !await _InstrumentItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
