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

            RuleFor(p => p.PipeDiameter!.Id)
         .NotEqual(0).WithMessage("Size is required.");


            RuleFor(p => p.ConnectionType!.Id)
         .NotEqual(0).WithMessage("Type is required.");


            RuleFor(p => p.nPipeClass!.Id)
         .NotEqual(0).WithMessage("Class is required.");

            RuleFor(p => p.StreamType)
              .NotEqual(Domain.Enums.StreamType.None)
              .WithMessage("In/Out type must be defined.");

            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandNozzle e, CancellationToken token)
        {
            return !await _NozzleRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
