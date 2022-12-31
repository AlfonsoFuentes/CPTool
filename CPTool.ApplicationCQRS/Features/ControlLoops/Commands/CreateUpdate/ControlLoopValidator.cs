using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate
{
    public class ControlLoopValidator : AbstractValidator<CommandControlLoop>
    {
        private readonly IRepositoryControlLoop _ControlLoopRepository;
        public ControlLoopValidator(IRepositoryControlLoop ControlLoopRepository)
        {
            _ControlLoopRepository = ControlLoopRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandControlLoop e, CancellationToken token)
        {
            return !await _ControlLoopRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
