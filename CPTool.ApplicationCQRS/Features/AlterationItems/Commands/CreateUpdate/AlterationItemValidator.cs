using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate
{
    public class AlterationItemValidator : AbstractValidator<CommandAlterationItem>
    {
        private readonly IRepositoryAlterationItem _AlterationItemRepository;
        public AlterationItemValidator(IRepositoryAlterationItem AlterationItemRepository)
        {
            _AlterationItemRepository = AlterationItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandAlterationItem e, CancellationToken token)
        {
            return !await _AlterationItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
