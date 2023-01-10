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
        private readonly IRepositoryNozzle _Repository;
        public NozzleValidator(IRepositoryNozzle Repository)
        {
            _Repository = Repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PipeDiameterId)
                .NotNull().WithMessage("Size is required.")
         .NotEqual(0).WithMessage("Size is required.");


            RuleFor(p => p.ConnectionTypeId)
                .NotNull().WithMessage("Type is required.")
         .NotEqual(0).WithMessage("Type is required.");


            RuleFor(p => p.nPipeClassId)
                 .NotNull().WithMessage("Class is required.")
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
            var result = await _Repository.Any(x => x.Id != e.Id && x.MWOItemId == e.MWOItemId && x.Name == e.Name);
            return !result;
        }
    }
}
