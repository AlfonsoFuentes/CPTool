using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate
{
    public class EquipmentTypeValidator : AbstractValidator<CommandEquipmentType>
    {
        private readonly IRepositoryEquipmentType _EquipmentTypeRepository;
        public EquipmentTypeValidator(IRepositoryEquipmentType EquipmentTypeRepository)
        {
            _EquipmentTypeRepository = EquipmentTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandEquipmentType e, CancellationToken token)
        {
            return !await _EquipmentTypeRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
