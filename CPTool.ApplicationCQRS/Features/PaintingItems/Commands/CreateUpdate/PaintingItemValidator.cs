using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate
{
    public class PaintingItemValidator : AbstractValidator<CommandPaintingItem>
    {
        private readonly IRepositoryPaintingItem _PaintingItemRepository;
        public PaintingItemValidator(IRepositoryPaintingItem PaintingItemRepository)
        {
            _PaintingItemRepository = PaintingItemRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandPaintingItem e, CancellationToken token)
        {
            return !await _PaintingItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
