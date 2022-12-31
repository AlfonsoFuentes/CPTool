using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate
{
    public class DeviceFunctionModifierValidator : AbstractValidator<CommandDeviceFunctionModifier>
    {
        private readonly IRepositoryDeviceFunctionModifier _DeviceFunctionModifierRepository;
        public DeviceFunctionModifierValidator(IRepositoryDeviceFunctionModifier DeviceFunctionModifierRepository)
        {
            _DeviceFunctionModifierRepository = DeviceFunctionModifierRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandDeviceFunctionModifier e, CancellationToken token)
        {
            return !await _DeviceFunctionModifierRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
