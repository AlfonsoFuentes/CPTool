using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate
{
    public class PipeDiameterValidator : AbstractValidator<CommandPipeDiameter>
    {
        private readonly IRepositoryPipeDiameter _PipeDiameterRepository;
        public PipeDiameterValidator(IRepositoryPipeDiameter PipeDiameterRepository)
        {
            _PipeDiameterRepository = PipeDiameterRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandPipeDiameter e, CancellationToken token)
        {
            return !await _PipeDiameterRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
