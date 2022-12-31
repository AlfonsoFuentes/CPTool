using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate
{
    public class ContingencyItemValidator : AbstractValidator<CommandContingencyItem>
    {
        private readonly IRepositoryContingencyItem _ContingencyItemRepository;
        public ContingencyItemValidator(IRepositoryContingencyItem ContingencyItemRepository)
        {
            _ContingencyItemRepository = ContingencyItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandContingencyItem e, CancellationToken token)
        {
            return !await _ContingencyItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
