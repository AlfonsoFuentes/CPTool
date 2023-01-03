using FluentValidation;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using CPTool.Persistence.Persistence;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate
{
    public class TaxCodeLDValidator : AbstractValidator<CommandTaxCodeLD>
    {
        private readonly IRepositoryTaxCodeLD _TaxCodeLDRepository;
        public TaxCodeLDValidator(IRepositoryTaxCodeLD TaxCodeLDRepository)
        {
            _TaxCodeLDRepository = TaxCodeLDRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");



            RuleFor(e => e)
                 .MustAsync(NameUnique)
                 .WithMessage($"Name already exists.");

        }



        private async Task<bool> NameUnique(CommandTaxCodeLD e, CancellationToken token)
        {
            return !await _TaxCodeLDRepository.IsPropertyUnique(e.Id,"Name",e.Name);
        }
    }
}
