using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate
{
    public class ReadoutValidator : AbstractValidator<CommandReadout>
    {
        private readonly IRepositoryReadout _ReadoutRepository;
        public ReadoutValidator(IRepositoryReadout ReadoutRepository)
        {
            _ReadoutRepository = ReadoutRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandReadout e, CancellationToken token)
        {
            return !await _ReadoutRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
