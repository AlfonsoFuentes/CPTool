using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate
{
    public class TestingItemValidator : AbstractValidator<CommandTestingItem>
    {
        private readonly IRepositoryTestingItem _TestingItemRepository;
        public TestingItemValidator(IRepositoryTestingItem TestingItemRepository)
        {
            _TestingItemRepository = TestingItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandTestingItem e, CancellationToken token)
        {
            return !await _TestingItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
