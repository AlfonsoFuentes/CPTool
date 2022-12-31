using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class EquipmentTypeSubValidator : AbstractValidator<CommandEquipmentTypeSub>
    {
        private readonly IRepositoryEquipmentTypeSub _EquipmentTypeSubRepository;
        public EquipmentTypeSubValidator(IRepositoryEquipmentTypeSub EquipmentTypeSubRepository)
        {
            _EquipmentTypeSubRepository = EquipmentTypeSubRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandEquipmentTypeSub e, CancellationToken token)
        {
            return !await _EquipmentTypeSubRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
