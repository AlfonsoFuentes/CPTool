using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate
{
    public class UnitaryBasePrizeValidator : AbstractValidator<CommandUnitaryBasePrize>
    {
        private readonly IRepositoryUnitaryBasePrize _UnitaryBasePrizeRepository;
        public UnitaryBasePrizeValidator(IRepositoryUnitaryBasePrize UnitaryBasePrizeRepository)
        {
            _UnitaryBasePrizeRepository = UnitaryBasePrizeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandUnitaryBasePrize e, CancellationToken token)
        {
            return !await _UnitaryBasePrizeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
