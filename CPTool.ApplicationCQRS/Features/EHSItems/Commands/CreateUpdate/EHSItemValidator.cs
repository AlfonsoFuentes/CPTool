using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate
{
    public class EHSItemValidator : AbstractValidator<CommandEHSItem>
    {
        private readonly IRepositoryEHSItem _EHSItemRepository;
        public EHSItemValidator(IRepositoryEHSItem EHSItemRepository)
        {
            _EHSItemRepository = EHSItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandEHSItem e, CancellationToken token)
        {
            return !await _EHSItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
