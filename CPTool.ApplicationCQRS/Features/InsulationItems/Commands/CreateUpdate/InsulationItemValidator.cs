using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate
{
    public class InsulationItemValidator : AbstractValidator<CommandInsulationItem>
    {
        private readonly IRepositoryInsulationItem _InsulationItemRepository;
        public InsulationItemValidator(IRepositoryInsulationItem InsulationItemRepository)
        {
            _InsulationItemRepository = InsulationItemRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandInsulationItem e, CancellationToken token)
        {
            return !await _InsulationItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
