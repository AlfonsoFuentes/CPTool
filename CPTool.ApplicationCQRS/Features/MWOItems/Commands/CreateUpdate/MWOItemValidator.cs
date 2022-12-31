using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class MWOItemValidator : AbstractValidator<CommandMWOItem>
    {
        private readonly IRepositoryMWOItem _MWOItemRepository;
        public MWOItemValidator(IRepositoryMWOItem MWOItemRepository)
        {
            _MWOItemRepository = MWOItemRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"MWO Type with the same name already exists.");

        }



        private async Task<bool> NameUnique(CommandMWOItem e, CancellationToken token)
        {
            return !await _MWOItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
