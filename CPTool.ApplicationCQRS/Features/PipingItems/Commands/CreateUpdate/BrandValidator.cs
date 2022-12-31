using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class PipingItemValidator : AbstractValidator<CommandPipingItem>
    {
        private readonly IRepositoryPipingItem _PipingItemRepository;
        public PipingItemValidator(IRepositoryPipingItem PipingItemRepository)
        {
            _PipingItemRepository = PipingItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandPipingItem e, CancellationToken token)
        {
            return !await _PipingItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
