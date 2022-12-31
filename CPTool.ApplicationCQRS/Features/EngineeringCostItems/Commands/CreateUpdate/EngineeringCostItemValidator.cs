using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate
{
    public class EngineeringCostItemValidator : AbstractValidator<CommandEngineeringCostItem>
    {
        private readonly IRepositoryEngineeringCostItem _EngineeringCostItemRepository;
        public EngineeringCostItemValidator(IRepositoryEngineeringCostItem EngineeringCostItemRepository)
        {
            _EngineeringCostItemRepository = EngineeringCostItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandEngineeringCostItem e, CancellationToken token)
        {
            return !await _EngineeringCostItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
