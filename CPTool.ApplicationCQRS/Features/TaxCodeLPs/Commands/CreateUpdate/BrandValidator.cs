using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate
{
    public class TaxCodeLPValidator : AbstractValidator<CommandTaxCodeLP>
    {
        private readonly IRepositoryTaxCodeLP _TaxCodeLPRepository;
        public TaxCodeLPValidator(IRepositoryTaxCodeLP TaxCodeLPRepository)
        {
            _TaxCodeLPRepository = TaxCodeLPRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandTaxCodeLP e, CancellationToken token)
        {
            return !await _TaxCodeLPRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
