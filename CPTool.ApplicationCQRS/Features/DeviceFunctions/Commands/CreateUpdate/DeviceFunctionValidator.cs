using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate
{
    public class DeviceFunctionValidator : AbstractValidator<CommandDeviceFunction>
    {
        private readonly IRepositoryDeviceFunction _DeviceFunctionRepository;
        public DeviceFunctionValidator(IRepositoryDeviceFunction DeviceFunctionRepository)
        {
            _DeviceFunctionRepository = DeviceFunctionRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandDeviceFunction e, CancellationToken token)
        {
            return !await _DeviceFunctionRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
