using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate
{
    public class ElectricalItemValidator : AbstractValidator<CommandElectricalItem>
    {
        private readonly IRepositoryElectricalItem _ElectricalItemRepository;
        public ElectricalItemValidator(IRepositoryElectricalItem ElectricalItemRepository)
        {
            _ElectricalItemRepository = ElectricalItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandElectricalItem e, CancellationToken token)
        {
            return !await _ElectricalItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
