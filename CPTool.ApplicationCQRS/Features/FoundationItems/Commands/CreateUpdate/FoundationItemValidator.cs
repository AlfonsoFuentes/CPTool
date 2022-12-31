using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate
{
    public class FoundationItemValidator : AbstractValidator<CommandFoundationItem>
    {
        private readonly IRepositoryFoundationItem _FoundationItemRepository;
        public FoundationItemValidator(IRepositoryFoundationItem FoundationItemRepository)
        {
            _FoundationItemRepository = FoundationItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandFoundationItem e, CancellationToken token)
        {
            return !await _FoundationItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
