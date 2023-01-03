using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate
{
    public class TaxesItemValidator : AbstractValidator<CommandTaxesItem>
    {
        private readonly IRepositoryTaxesItem _TaxesItemRepository;
        public TaxesItemValidator(IRepositoryTaxesItem TaxesItemRepository)
        {
            _TaxesItemRepository = TaxesItemRepository;

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            //RuleFor(e => e)
            //     .MustAsync(NameUnique)
            //     .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandTaxesItem e, CancellationToken token)
        {
            return !await _TaxesItemRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
