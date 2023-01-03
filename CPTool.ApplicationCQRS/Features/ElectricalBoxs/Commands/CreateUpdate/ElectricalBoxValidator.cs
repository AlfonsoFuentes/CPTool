using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate
{
    public class ElectricalBoxValidator : AbstractValidator<CommandElectricalBox>
    {
        private readonly IRepositoryElectricalBox _ElectricalBoxRepository;
        public ElectricalBoxValidator(IRepositoryElectricalBox ElectricalBoxRepository)
        {
            _ElectricalBoxRepository = ElectricalBoxRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandElectricalBox e, CancellationToken token)
        {
            return !await _ElectricalBoxRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
