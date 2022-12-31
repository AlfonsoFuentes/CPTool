using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class EquipmentItemValidator : AbstractValidator<CommandEquipmentItem>
    {
        private readonly IRepositoryEquipmentItem _EquipmentItemRepository;
        public EquipmentItemValidator(IRepositoryEquipmentItem EquipmentItemRepository)
        {
            _EquipmentItemRepository = EquipmentItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandEquipmentItem e, CancellationToken token)
        {
            return !await _EquipmentItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
