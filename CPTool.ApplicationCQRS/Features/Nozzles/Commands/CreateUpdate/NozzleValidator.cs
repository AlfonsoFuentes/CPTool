using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate
{
    public class NozzleValidator : AbstractValidator<CommandNozzle>
    {
        private readonly IRepositoryNozzle _NozzleRepository;
        public NozzleValidator(IRepositoryNozzle NozzleRepository)
        {
            _NozzleRepository = NozzleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandNozzle e, CancellationToken token)
        {
            return !await _NozzleRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
